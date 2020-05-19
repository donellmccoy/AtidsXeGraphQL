using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace TheFund.AtidsXe.GraphQL.Models
{
    public interface IGraphQLSettings
    {
        PathString Path { get; set; }
        Func<HttpContext, IDictionary<string, object>> BuildUserContext { get; set; }
        bool EnableMetrics { get; set; }
        bool ExposeExceptions { get; set; }
        int? ComplexityMaxDepth { get; set; }
        int? FieldImpact { get; set; }
        int? MaxComplexity { get; set; }
    }
}