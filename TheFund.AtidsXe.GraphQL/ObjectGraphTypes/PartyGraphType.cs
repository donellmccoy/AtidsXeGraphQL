using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PartyGraphType : ObjectGraphType<Party>
    {
        private readonly IEFDataStore _efDataStore;

        public PartyGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}