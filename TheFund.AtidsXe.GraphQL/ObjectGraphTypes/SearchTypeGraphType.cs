using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SearchTypeGraphType : ObjectGraphTypeBase<SearchType>
    {
        public SearchTypeGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(SearchTypeGraphType);
            Description = nameof(SearchTypeGraphType);

            Field(p => p.SearchTypeId);
            Field(p => p.Description, true);
        }
    }
}