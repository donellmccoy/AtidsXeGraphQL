using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class NameSearchListItemGraphType : ObjectGraphType<NameSearchListItem>
    {
        public NameSearchListItemGraphType(IEFDataStore dataStore)
        {
            Field(p => p.NameSearchListItemId);
            Field(p => p.LegalEntityNameId);
            Field(p => p.ChainOfTitleId);
            Field(p => p.NameSearchStatusCodeId);
            Field(p => p.ReferenceTitleEventId);

            FieldAsync<TitleEventGraphType, TitleEvent>
            (
                FieldNames.GeographicLocale,
                "Geographic locale for this file reference",
                null,
                context => dataStore.GetEntityAsync<TitleEvent>(p => p.TitleEventId == context.Source.ReferenceTitleEventId, context.CancellationToken));
        }
    }
}