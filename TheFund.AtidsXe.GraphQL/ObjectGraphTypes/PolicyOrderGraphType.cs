using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyOrderGraphType : ObjectGraphType<PolicyOrder>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicyOrderGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}