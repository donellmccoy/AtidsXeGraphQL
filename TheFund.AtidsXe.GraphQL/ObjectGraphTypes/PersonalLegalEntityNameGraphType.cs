using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PersonalLegalEntityNameGraphType : ObjectGraphType<PersonalLegalEntityName>
    {
        private readonly IEFDataStore _efDataStore;

        public PersonalLegalEntityNameGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}