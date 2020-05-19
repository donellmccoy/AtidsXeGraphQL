using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class RelatedTaxFolioGraphType : ObjectGraphType<RelatedTaxFolio>
    {
        private readonly IEFDataStore _efDataStore;

        public RelatedTaxFolioGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}