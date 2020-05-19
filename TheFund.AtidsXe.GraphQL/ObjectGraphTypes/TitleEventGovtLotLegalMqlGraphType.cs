using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventGovtLotLegalMqlGraphType : ObjectGraphType<TitleEventGovtLotLegalMql>
    {
        public TitleEventGovtLotLegalMqlGraphType(IEFDataStore dataStore)
        {
            Field(p => p.UnplattedReferenceId);
            Field(p => p.GovernmentLotId);
            Field(p => p.TitleEventId);

            FieldAsync<TitleEventGraphType, TitleEvent>
            (
                FieldNames.TitleEvent,
                "Title event associated with this gov lot lega mql",
                null,
                context => dataStore.GetEntityAsync<TitleEvent>(p => p.TitleEventId == context.Source.TitleEventId, context.CancellationToken));
        }
    }
}