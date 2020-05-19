using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace TheFund.AtidsXe.GraphQL.Models
{
    public sealed class GraphQLSettings : IGraphQLSettings
    {
        public PathString Path { get; set; }
        public Func<HttpContext, IDictionary<string, object>> BuildUserContext { get; set; }
        public bool EnableMetrics { get; set; }
        public bool ExposeExceptions { get; set; }
        public int? ComplexityMaxDepth { get; set; }
        public int? FieldImpact { get; set; }
        public int? MaxComplexity { get; set; }
    }
}
