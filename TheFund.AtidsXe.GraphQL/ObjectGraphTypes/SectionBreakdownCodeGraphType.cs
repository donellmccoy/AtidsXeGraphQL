using GraphQL.Types;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SectionBreakdownCodeGraphType : ObjectGraphType<SectionBreakdownCode>
    {
        public SectionBreakdownCodeGraphType()
        {
            Field(p => p.SectionBreakdownCodeId);
            Field(p => p.Section16th, true);
            Field(p => p.Section256th, true);
            Field(p => p.Section64th, true);
            Field(p => p.SectionQuarter);
        }
    }
}