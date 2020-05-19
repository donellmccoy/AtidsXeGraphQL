using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class NameSearchListReasonCodeGraphType : ObjectGraphType<NameSearchListReasonCode>
    {
        private readonly IEFDataStore _efDataStore;

        public NameSearchListReasonCodeGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}