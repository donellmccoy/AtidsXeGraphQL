using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class LegalEntityNameGraphType : ObjectGraphType<LegalEntityName>
    {
        private readonly IEFDataStore _efDataStore;

        public LegalEntityNameGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}