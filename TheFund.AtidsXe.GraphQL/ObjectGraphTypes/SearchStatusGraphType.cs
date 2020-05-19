using GraphQL.Types;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SearchStatusGraphType : ObjectGraphType<SearchStatus>
    {
        public SearchStatusGraphType()
        {
            Name = nameof(SearchStatusGraphType);
            Description = nameof(SearchStatusGraphType);

            Field(p => p.SearchStatusId);
            Field(p => p.Description, true);
        }
    }
}