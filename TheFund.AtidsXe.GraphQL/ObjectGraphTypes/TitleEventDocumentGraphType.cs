using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventDocumentGraphType : ObjectGraphType<TitleEventDocument>
    {
        private readonly IEFDataStore _efDataStore;

        public TitleEventDocumentGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}