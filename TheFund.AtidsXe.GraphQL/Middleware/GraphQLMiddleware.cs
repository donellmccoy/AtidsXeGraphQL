using GraphQL;
using GraphQL.Execution;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TheFund.AtidsXe.GraphQL.Models;
using TheFund.AtidsXe.Server.Services;

namespace TheFund.AtidsXe.GraphQL.Middleware
{
    public sealed class GraphQLMiddleware
    {
        #region Fields

        private readonly RequestDelegate _requestDelegate;
        private readonly IGraphQLSettings _graphQLSettings;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly IDocumentWriter _documentWriter;
        private readonly IDocumentExecutionListener _documentExecutionListener;
        private readonly IServiceProvider _serviceProvider;
        private readonly IQueryLookupService _graphQLMappingService;

        #endregion

        #region Constructors

        public GraphQLMiddleware(
            RequestDelegate requestDelegate,
            IGraphQLSettings graphQLSettings,
            IDocumentExecuter documentExecuter,
            IDocumentWriter documentWriter,
            IDocumentExecutionListener documentExecutionListener,
            IServiceProvider serviceProvider, 
            IQueryLookupService graphQLMappingService)
        {
            _requestDelegate = requestDelegate;
            _graphQLSettings = graphQLSettings;
            _documentExecuter = documentExecuter;
            _documentWriter = documentWriter;
            _documentExecutionListener = documentExecutionListener;
            _serviceProvider = serviceProvider;
            _graphQLMappingService = graphQLMappingService;
        }

        #endregion

        #region Methods

        public async Task Invoke(HttpContext context, ISchema schema)
        {
            if (!IsGraphQLRequest(context))
            {
                await _requestDelegate(context);
                return;
            }
            
            await ExecuteAsync(context, schema);
        }

        private bool IsGraphQLRequest(HttpContext context)
        {
            if (context.RequestAborted.IsCancellationRequested)
            {
                return false;
            }
            return context.Request.Path.StartsWithSegments(_graphQLSettings.Path)
                && string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase);
        }

        private (JObject Variables, string OperationName, string Query) CreateNewRequest(HttpContext context)
        {
            var request = Deserialize<GraphQLRequest>(context.Request.Body);
            var query = request.HasQueryId ? _graphQLMappingService.GetQueryById(request.QueryId) : request.Query;
            return (request.Variables, request.OperationName, query);
        }

        private async Task ExecuteAsync(HttpContext context, ISchema schema)
        {
            var (variables, operationName, query) = CreateNewRequest(context);

            var result = await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query;
                _.OperationName = operationName;
                _.Inputs = variables?.ToInputs();
                _.CancellationToken = context.RequestAborted;
                _.ComplexityConfiguration = new ComplexityConfiguration 
                { 
                    MaxDepth = _graphQLSettings.ComplexityMaxDepth, 
                    FieldImpact = _graphQLSettings.FieldImpact, 
                    MaxComplexity = _graphQLSettings.MaxComplexity
                };
                _.UserContext = _graphQLSettings.BuildUserContext?.Invoke(context);
                _.EnableMetrics = _graphQLSettings.EnableMetrics;
                _.ExposeExceptions = _graphQLSettings.ExposeExceptions;
                _.Listeners.Add(_serviceProvider.GetService<IDocumentExecutionListener>());

                //_.ValidationRules = DocumentValidator.CoreRules().Concat(new[] { new InputValidationRule() });

                if (_graphQLSettings.EnableMetrics)
                {
                    _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                }

            }).ConfigureAwait(false);

            if (_graphQLSettings.EnableMetrics)
            {
                result.EnrichWithApolloTracing(DateTime.UtcNow);
            }

            await WriteResponseAsync(context, result);
        }

        private async Task WriteResponseAsync(HttpContext context, ExecutionResult executionResult)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = executionResult.Errors?.Any() == true ? (int)HttpStatusCode.BadRequest : (int)HttpStatusCode.OK;
            
            await _documentWriter.WriteAsync(context.Response.Body, executionResult);
        }

        private static T Deserialize<T>(Stream stream) where T: class
        {
            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);
            return new JsonSerializer().Deserialize<T>(jsonTextReader);
        }

        #endregion
    }
}
