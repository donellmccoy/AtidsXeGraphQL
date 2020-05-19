using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class ExaminationStatusTypeGraphType : ObjectGraphType<ExaminationStatusType>
    {
        private readonly IEFDataStore _dataStore;

        public ExaminationStatusTypeGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;
            Field(p => p.ExaminationStatusTypeId);
            Field(p => p.Description, true);
        }
    }
}