using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventStatusAssignOfficialRecordGraphType : ObjectGraphType<TitleEventStatusAssignor>
    {
        private readonly IEFDataStore _dataStore;

        public TitleEventStatusAssignOfficialRecordGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Field(p => p.TitleEventStatusAssignorId);
            Field(p => p.Description, true);
        }
    }
}