using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SubdivisionLevelsGraphType : ObjectGraphTypeBase<SubdivisionLevels>
    {
        public SubdivisionLevelsGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(SubdivisionLevelsGraphType);
            Description = nameof(SubdivisionLevelsGraphType);

            Field(p => p.SubdivisionLevelId);
            Field<StringGraphType>(FieldNames.Level1, context => context.Source.Level1.TrimIfNotNull());
            Field<StringGraphType>(FieldNames.Level2, context => context.Source.Level2.TrimIfNotNull());
            Field<StringGraphType>(FieldNames.Level3, context => context.Source.Level3.TrimIfNotNull());
        }
    }
}