using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class NameSearchStatusCodeGraphType : ObjectGraphType<NameSearchStatusCode>
    {
        private readonly IEFDataStore _efDataStore;

        public NameSearchStatusCodeGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}