using GraphQL.Types;
using TheFund.AtidsXe.GraphQL.Extensions;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class MortgageTitleEventGraphType : ObjectGraphType<MortgageTitleEvent>
    {
        private readonly IEFDataStore _dataStore;

        public MortgageTitleEventGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Field(p => p.TitleEventId);
            Field(p => p.MinNumberId);
            Field<StringGraphType>(
                FieldNames.LenderName,
                "The lender's name for this mortgage title event",
                null,
                fieldContext => fieldContext.Source.LenderName.TrimIfNotNull()
            );
        }
    }
}