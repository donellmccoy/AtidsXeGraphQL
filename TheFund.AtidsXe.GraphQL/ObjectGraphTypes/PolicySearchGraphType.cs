using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicySearchGraphType : ObjectGraphType<PolicySearch>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicySearchGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}