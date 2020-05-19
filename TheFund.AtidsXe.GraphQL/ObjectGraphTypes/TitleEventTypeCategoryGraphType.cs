using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventTypeCategoryGraphType : ObjectGraphType<TitleEventTypeCategory>
    {
        private readonly IEFDataStore _efDataStore;

        public TitleEventTypeCategoryGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}