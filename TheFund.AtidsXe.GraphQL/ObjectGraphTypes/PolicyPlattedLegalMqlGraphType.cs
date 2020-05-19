using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyPlattedLegalMqlGraphType : ObjectGraphType<PolicyPlattedLegalMql>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicyPlattedLegalMqlGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;

            Field(p => p.PlatReferenceId);
            Field(p => p.PolicyId);
            Field(p => p.SubdivisionLevelId);
        }
    }
}