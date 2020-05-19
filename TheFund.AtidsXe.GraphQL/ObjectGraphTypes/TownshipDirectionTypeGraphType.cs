using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TownshipDirectionTypeGraphType : ObjectGraphTypeBase<TownshipDirectionType>
    {
        public TownshipDirectionTypeGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(TownshipDirectionTypeGraphType);
            Description = nameof(TownshipDirectionTypeGraphType);

            Field(p => p.TownshipDirectionTypeId);
            Field(p => p.Description, true);
        }
    }
}