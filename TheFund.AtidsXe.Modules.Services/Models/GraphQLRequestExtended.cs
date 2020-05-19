using GraphQL.Common.Request;

namespace TheFund.AtidsXe.Modules.Services.Models
{
    public class GraphQLRequestExtended : GraphQLRequest
    {
        public string QueryId { get; set; }

        public bool HasQueryId => !string.IsNullOrWhiteSpace(QueryId);
    }
}