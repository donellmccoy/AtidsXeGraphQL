using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PropertyAddressGraphType : ObjectGraphType<PropertyAddress>
    {
        private readonly IEFDataStore _efDataStore;

        public PropertyAddressGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}