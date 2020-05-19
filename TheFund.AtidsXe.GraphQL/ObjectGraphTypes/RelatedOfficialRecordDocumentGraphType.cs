using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class RelatedOfficialRecordDocumentGraphType : ObjectGraphType<RelatedOrDocument>
    {
        private readonly IEFDataStore _efDataStore;

        public RelatedOfficialRecordDocumentGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}