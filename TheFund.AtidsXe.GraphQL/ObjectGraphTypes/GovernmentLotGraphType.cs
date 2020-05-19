using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class GovernmentLotGraphType : ObjectGraphTypeBase<GovernmentLot>
    {
        public GovernmentLotGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(GovernmentLotGraphType);
            Description = nameof(GovernmentLotGraphType);

            Field(p => p.GovernmentLotId);
            Field(p => p.GovernmentLotNumber, true);
        }
    }
}