using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TaxFolioReferenceGraphType : ObjectGraphType<TaxFolioReference>
    {
        private readonly IEFDataStore _efDataStore;

        public TaxFolioReferenceGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}