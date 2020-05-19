using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyRestrictionTypeGraphType : ObjectGraphType<PolicyRestrictionType>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicyRestrictionTypeGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}