using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleSearchOriginationGraphType : ObjectGraphType<TitleSearchOrigination>
    {
        public TitleSearchOriginationGraphType(IEFDataStore dataStore)
        {
            Field(p => p.TitleEventId);
            Field(p => p.TitleSearchOriginationId);
            Field(p => p.OrderDate);
            Field(p => p.OrderReference, true);
            Field(p => p.FileReferenceId);

            FieldAsync<TitleEventGraphType, TitleEvent>
            (
                FieldNames.TitleEvent,
                "Title event associated with this title origination",
                null,
                context => dataStore.GetEntityAsync<TitleEvent>(p => p.TitleEventId == context.Source.TitleEventId, context.CancellationToken));
        }
    }
}