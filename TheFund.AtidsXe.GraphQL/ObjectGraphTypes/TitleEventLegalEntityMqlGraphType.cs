using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventLegalEntityMqlGraphType : ObjectGraphType<TitleEventLegalEntityMql>
    {
        private readonly IEFDataStore _dataStore;

        public TitleEventLegalEntityMqlGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Field(x => x.TitleEventId);
            Field(x => x.LegalEntityNameId);

            FieldAsync<TitleEventGraphType, TitleEvent>
            (
                FieldNames.TitleEvent,
                "Title event associated with this legal entity mql",
                null,
                context => dataStore.GetEntityAsync<TitleEvent>(p => p.TitleEventId == context.Source.TitleEventId, context.CancellationToken));
        }
    }
}