using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyNotesGraphType : ObjectGraphType<PolicyNotes>
    {
        private readonly IEFDataStore _efDataStore;

        public PolicyNotesGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;
        }
    }
}