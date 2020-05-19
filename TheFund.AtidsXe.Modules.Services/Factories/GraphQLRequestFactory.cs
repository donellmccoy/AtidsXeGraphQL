using System.Linq;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class GraphQLRequestFactory
    {
        public static GraphQLRequestExtended Create(string queryId, params (string, object)[] variables)
        {
            return new GraphQLRequestExtended
            {
                QueryId = queryId,
                Query = queryId,
                OperationName = null,
                Variables = variables.ToDictionary(variable => variable.Item1, variable => variable.Item2)
            };
        }
    }
}
