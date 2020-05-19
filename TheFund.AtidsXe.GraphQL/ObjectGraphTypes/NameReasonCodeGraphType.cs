using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class NameReasonCodeGraphType : ObjectGraphType<NameReasonCode>
    {
        private readonly IEFDataStore _efDataStore;

        public NameReasonCodeGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}