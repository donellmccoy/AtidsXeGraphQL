using TheFund.AtidsXe.GraphQL.Models;

namespace TheFund.AtidsXe.Server.Services
{
    public interface IQueryLookupService
    {
        GraphQLMapping GetQueryMappingById(string queryId);
        string GetQueryById(string queryId);
    }
}