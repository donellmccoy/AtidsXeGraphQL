using Newtonsoft.Json.Linq;

namespace TheFund.AtidsXe.GraphQL.Models
{
    internal sealed class GraphQLRequest
    {
        public string QueryId { get; set; }

        public bool HasQueryId => !string.IsNullOrWhiteSpace(QueryId);

        public string OperationName { get; set; }

        public string Query { get; set; }

        public JObject Variables { get; set; }
    }
}