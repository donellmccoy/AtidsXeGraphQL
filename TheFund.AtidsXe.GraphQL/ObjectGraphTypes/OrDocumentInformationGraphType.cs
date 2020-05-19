using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class OrDocumentInformationGraphType : ObjectGraphType<OrDocumentInformation>
    {
        private readonly IEFDataStore _efDataStore;

        public OrDocumentInformationGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}