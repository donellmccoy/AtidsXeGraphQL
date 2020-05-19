﻿using Newtonsoft.Json.Linq;

namespace TheFund.AtidsXe.GraphQL.Models
{
    public sealed class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
