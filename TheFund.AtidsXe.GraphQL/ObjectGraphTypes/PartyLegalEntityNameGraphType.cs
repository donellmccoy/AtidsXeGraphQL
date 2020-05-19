using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PartyLegalEntityNameGraphType : ObjectGraphType<PartyLegalEntityName>
    {
        private readonly IEFDataStore _efDataStore;

        public PartyLegalEntityNameGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}