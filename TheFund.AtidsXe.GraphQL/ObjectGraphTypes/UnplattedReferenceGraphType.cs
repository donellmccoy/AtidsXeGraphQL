using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class UnplattedReferenceGraphType : ObjectGraphTypeBase<UnplattedReference>
    {
        public UnplattedReferenceGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Field(p => p.UnplattedReferenceId);
            Field(p => p.BreakdownCodeTypeId);
            Field(p => p.RangeDirectionTypeId);
            Field(p => p.TownshipDirectionTypeId);
            Field(p => p.Meridian, true);
            Field(p => p.Range, true);
            Field(p => p.Township, true);
            Field(p => p.Section, true);

            //breakdowncodetype
            //RangeDirectionType
            //TownshipDirectionType
            //list:GovernmentLotLegal
            //list:SectionLegal
        }
    }
}