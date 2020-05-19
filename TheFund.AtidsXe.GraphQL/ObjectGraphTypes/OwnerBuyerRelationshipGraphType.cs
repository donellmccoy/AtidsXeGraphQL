using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class OwnerBuyerRelationshipGraphType : ObjectGraphType<OwnerBuyerRelationship>
    {
        private readonly IEFDataStore _efDataStore;

        public OwnerBuyerRelationshipGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}