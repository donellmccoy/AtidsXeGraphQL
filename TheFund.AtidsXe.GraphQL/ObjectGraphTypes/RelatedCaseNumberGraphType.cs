using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class RelatedCaseNumberGraphType : ObjectGraphType<RelatedCaseNumber>
    {
        private readonly IEFDataStore _efDataStore;

        public RelatedCaseNumberGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}