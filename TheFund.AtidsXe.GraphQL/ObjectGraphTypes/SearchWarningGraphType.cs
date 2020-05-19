using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SearchWarningGraphType : ObjectGraphTypeBase<SearchWarning>
    {
        public SearchWarningGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(SearchWarningGraphType);
            Description = nameof(SearchWarningGraphType);

            Field(p => p.SearchWarningTypeId);
            Field(p => p.SearchWarningId);
            Field(p => p.SearchId);
            Field(p => p.CreateDate, true);
            Field<StringGraphType>(FieldNames.UnparsedSearchWarning, context => context.Source.UnparsedSearchWarning.TrimIfNotNull());
            Field<SearchWarningTypeGraphType, SearchWarningType>(
                FieldNames.SearchWarningType,
                p => p.SearchWarningTypeId,
                p => p.SearchWarningTypeId);
        }
    }
}