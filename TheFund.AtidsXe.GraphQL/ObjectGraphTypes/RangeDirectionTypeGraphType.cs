using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class RangeDirectionTypeGraphType : ObjectGraphTypeBase<RangeDirectionType>
    {
        public RangeDirectionTypeGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(RangeDirectionTypeGraphType);
            Description = nameof(RangeDirectionTypeGraphType);

            Field(p => p.RangeDirectionTypeId);
            Field(p => p.Description, true);
        }
    }
}