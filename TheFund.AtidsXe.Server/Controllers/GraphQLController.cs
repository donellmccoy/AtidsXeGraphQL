using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TheFund.AtidsXe.GraphQL;
using TheFund.AtidsXe.GraphQL.Models;

namespace TheFund.AtidsXe.Server.Controllers
{
    /// <summary>
    /// Class GraphQLController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        /// <summary>
        /// The schema
        /// </summary>
        private readonly ISchema _schema;
        /// <summary>
        /// The graph ql settings
        /// </summary>
        private readonly GraphQLSettings _graphQLSettings;
        /// <summary>
        /// The document executer
        /// </summary>
        private readonly IDocumentExecuter _documentExecuter;
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphQLController"/> class.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="graphQLSettings">The graph ql settings.</param>
        /// <param name="documentExecuter">The document executer.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public GraphQLController(ISchema schema,
            GraphQLSettings graphQLSettings,
            IDocumentExecuter documentExecuter, 
            IServiceProvider serviceProvider)
        {
            _schema = schema;
            _graphQLSettings = graphQLSettings;
            _documentExecuter = documentExecuter;
            _serviceProvider = serviceProvider;
        }
        /// <summary>
        /// Posts the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query is null)
            {
                return BadRequest($"The parameter: {nameof(query)} cannot be null");
            }

            if(string.IsNullOrWhiteSpace(query.Query))
            {
                return BadRequest($"The parameter: {nameof(query.Query)} cannot be null or empty string");
            }

            var executionResult = await _documentExecuter.ExecuteAsync(executionOptions =>
            {
                executionOptions.Schema = _schema;
                executionOptions.Query = query.Query;
                executionOptions.OperationName = query.OperationName;
                executionOptions.Inputs = query.Variables.ToInputs();
                executionOptions.EnableMetrics = _graphQLSettings.EnableMetrics;
                executionOptions.ExposeExceptions = true;
                executionOptions.Listeners.Add(_serviceProvider.GetService<DataLoaderDocumentListener>());
            }).ConfigureAwait(false);

            if (executionResult.Errors?.Count > 0)
            {
                return BadRequest(executionResult);
            }

            return Ok(executionResult);
        }
    }
}
