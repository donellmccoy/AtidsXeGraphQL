using GraphQL.Types;
using TheFund.AtidsXe.GraphQL.Extensions;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventTypeGraphType : ObjectGraphType<Entities.Models.TitleEventType>
    {
        private readonly IEFDataStore _dataStore;

        public TitleEventTypeGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Field(p => p.TitleEventTypeId);
            Field(p => p.EventCategoryId);
            Field<StringGraphType>(
                FieldNames.Description,
                "Description of title event type", 
                null,
                fieldContext => fieldContext.Source.Description.TrimIfNotNull()
            );
            Field<StringGraphType>(
                FieldNames.TitleEventCode,
                "Title event code for this title event type",
                null,
                fieldContext => fieldContext.Source.TitleEventCode.TrimIfNotNull()
            );
        }
    }
}