using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventSectionLegalMqlGraphType : ObjectGraphType<TitleEventSectionLegalMql>
    {
        private readonly IEFDataStore _dataStore;

        public TitleEventSectionLegalMqlGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Field(p => p.TitleEventId);
            Field(p => p.SectionBreakdownCodeId);
            Field(p => p.UnplattedReferenceId);

            FieldAsync<TitleEventGraphType, TitleEvent>
            (
                FieldNames.TitleEvent,
                "Title event associated with this section legal mql",
                null,
                context => dataStore.GetEntityAsync<TitleEvent>(p => p.TitleEventId == context.Source.TitleEventId, context.CancellationToken));
        }
    }
}