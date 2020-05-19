using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class BreakdownCodeTypeGraphType : ObjectGraphTypeBase<BreakdownCodeType>
    {
        public BreakdownCodeTypeGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(BreakdownCodeTypeGraphType);
            Description = nameof(BreakdownCodeTypeGraphType);

            Field(p => p.BreakdownCodeTypeId);
            Field(p => p.Description, true);
            FieldListAsync<UnplattedReferenceGraphType, UnplattedReference>(
                FieldNames.UnplattedReferences,
                p => p.BreakdownCodeTypeId,
                p => p.BreakdownCodeTypeId);
        }
    }
}