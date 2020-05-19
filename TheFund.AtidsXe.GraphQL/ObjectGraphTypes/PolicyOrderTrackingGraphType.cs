using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyOrderTrackingGraphType : ObjectGraphType<PolicyOrderTracking>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicyOrderTrackingGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}