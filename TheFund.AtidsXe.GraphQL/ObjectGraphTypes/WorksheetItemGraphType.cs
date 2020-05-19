using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class WorksheetItemGraphType : ObjectGraphType<WorksheetItem>
    {
        public WorksheetItemGraphType(
            ITitleEventRepository titleEventRepository, 
            IDataLoaderContextAccessor accessor)
        {
            Field(x => x.TitleEventId);
            Field(x => x.WorksheetId);
            Field(x => x.Sequence);

            Field<TitleEventGraphType, TitleEvent>()
                .Name(FieldNames.TitleEvent)
                .ResolveAsync(context => accessor.Context.GetOrAddBatchLoader(nameof(titleEventRepository.GetTitleEventsByIdAsync),
                    (Func<IEnumerable<int>, Task<IDictionary<int, TitleEvent>>>)(keys => titleEventRepository.GetTitleEventsByIdAsync(keys, context.CancellationToken))).LoadAsync(context.Source.TitleEventId));
        }
    }
}