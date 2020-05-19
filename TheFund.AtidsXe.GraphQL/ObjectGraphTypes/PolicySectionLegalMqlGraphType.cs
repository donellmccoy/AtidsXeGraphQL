using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicySectionLegalMqlGraphType : ObjectGraphType<PolicySectionLegalMql>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicySectionLegalMqlGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}