using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class LegalEntityNameTypeGraphType : ObjectGraphType<LegalEntityNameType>
    {
        private readonly IEFDataStore _efDataStore;

        public LegalEntityNameTypeGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}