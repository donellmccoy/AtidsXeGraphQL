using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SearchNotesGraphType : ObjectGraphType<SearchNotes>
    {
        private readonly IEFDataStore _efDataStore;

        public SearchNotesGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}