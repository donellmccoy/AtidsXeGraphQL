using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class DeliveryOrderInfoGraphType : ObjectGraphType<DeliveryOrderInfo>
    {
        private readonly IEFDataStore _efDataStore;

        public DeliveryOrderInfoGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}