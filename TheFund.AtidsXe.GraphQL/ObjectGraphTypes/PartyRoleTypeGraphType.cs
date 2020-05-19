using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PartyRoleTypeGraphType : ObjectGraphType<PartyRoleType>
    {
        private readonly IEFDataStore _efDataStore;

        public PartyRoleTypeGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}