using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SearchWarningTypeGraphType : ObjectGraphTypeBase<SearchWarningType>
    {
        public SearchWarningTypeGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(SearchWarningTypeGraphType);
            Description = nameof(SearchWarningTypeGraphType);

            Field(p => p.SearchWarningTypeId);
            Field<StringGraphType>(FieldNames.Description, context => context.Source.Description.TrimIfNotNull());
            Field<SearchWarningHelpGraphType, SearchWarningHelp>(
                FieldNames.SearchWarningHelp,
                p => p.SearchWarningTypeId,
                p => p.SearchWarningTypeId);
            FieldListAsync<SearchWarningGraphType, SearchWarning>(
                FieldNames.SearchWarnings,
                p => p.SearchWarningTypeId,
                p => p.SearchWarningTypeId);
        }
    }
}