using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyInsuredDocumentGraphType : ObjectGraphType<PolicyInsuredDocument>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicyInsuredDocumentGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}