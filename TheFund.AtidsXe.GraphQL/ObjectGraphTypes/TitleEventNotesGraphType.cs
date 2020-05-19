using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventNotesGraphType : ObjectGraphType<TitleEventNotes>
    {
        private readonly IEFDataStore _dataStore;

        public TitleEventNotesGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Field(p => p.TitleEventId);
            Field(p => p.UserId, true);
            Field(p => p.TimeStamp);
            Field(p => p.Message, true);

            FieldAsync<TitleEventGraphType, TitleEvent>
            (
                FieldNames.TitleEvent,
                "Title event associated with this title event note",
                null,
                context => dataStore.GetEntityAsync<TitleEvent>(p => p.TitleEventId == context.Source.TitleEventId, context.CancellationToken));
        }
    }
}