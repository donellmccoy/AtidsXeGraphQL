using System.Collections.Generic;
using System.Security.Claims;

namespace TheFund.AtidsXe.GraphQL.Models
{
    public sealed class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
