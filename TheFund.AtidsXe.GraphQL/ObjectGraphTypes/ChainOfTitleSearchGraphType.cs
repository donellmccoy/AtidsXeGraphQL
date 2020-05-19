using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class ChainOfTitleSearchGraphType : ObjectGraphType<ChainOfTitleSearch>
    {
        public ChainOfTitleSearchGraphType(
            ISearchRepository repository,
            IDataLoaderContextAccessor accessor)
        {
            Name = nameof(ChainOfTitleSearchGraphType);
            Description = nameof(ChainOfTitleSearchGraphType);

            Field(p => p.ChainOfTitleId);
            Field(p => p.SearchId);

            Field<SearchGraphType, Search>()
                .Name(FieldNames.Search)
                .ResolveAsync(context => accessor.Context.GetOrAddBatchLoader(nameof(repository.GetSearchByKeysAsync), 
                (Func<IEnumerable<int>, Task<IDictionary<int, Search>>>)(keys => repository.GetSearchByKeysAsync(keys, context.CancellationToken))).LoadAsync(context.Source.SearchId));
        }
    }
}