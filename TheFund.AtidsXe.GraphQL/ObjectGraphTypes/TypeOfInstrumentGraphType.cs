using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TypeOfInstrumentGraphType : ObjectGraphType<TypeOfInstrument>
    {
        private readonly IEFDataStore _efDataStore;

        public TypeOfInstrumentGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}