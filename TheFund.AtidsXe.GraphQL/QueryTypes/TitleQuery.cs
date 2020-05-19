using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Properties;

namespace TheFund.AtidsXe.GraphQL.QueryTypes
{
    public sealed class TitleQuery : ObjectGraphType
    {
        public TitleQuery(IEFDataStore dataStore)
        {
            Name = "TitleQuery";
            Description = Resources.Queries_for_the_Title_Event_table;

            FieldAsync<ObjectGraphTypes.TitleEventGraphType, TitleEvent>
            (
                FieldNames.TitleEvent,
                Resources.Gets_a_single_title_event_record_by_id,
                new QueryArguments
                (
                    new QueryArgument<IntGraphType>
                    {
                        Name = ArgumentNames.TitleEventId,
                        Description = "The title event primary key"
                    }
                ),
                context =>
                {
                    var titleEventId = context.GetArgument<int>(ArgumentNames.TitleEventId);
                    return dataStore.GetEntityAsync<TitleEvent>(p => p.TitleEventId == titleEventId, context.CancellationToken);
                });
        }
    }
}
