using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SearchWarningHelpGraphType : ObjectGraphTypeBase<SearchWarningHelp>
    {
        public SearchWarningHelpGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(SearchWarningHelpGraphType);
            Description = nameof(SearchWarningHelpGraphType);

            Field(p => p.SearchWarningTypeId);
            Field<StringGraphType>(FieldNames.HelpText, context => context.Source.HelpText.TrimIfNotNull());
            Field<SearchWarningTypeGraphType, SearchWarningType>(
                FieldNames.SearchWarningType,
                p => p.SearchWarningTypeId,
                p => p.SearchWarningTypeId);
        }
    }
}