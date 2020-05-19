using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyGovtLotLegalMqlGraphType : ObjectGraphType<PolicyGovtLotLegalMql>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicyGovtLotLegalMqlGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}