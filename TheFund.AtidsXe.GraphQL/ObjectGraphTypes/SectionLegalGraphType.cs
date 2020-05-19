using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SectionLegalGraphType : ObjectGraphTypeBase<SectionLegal>
    {
        public SectionLegalGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Field(p => p.SectionBreakdownCodeId);
            Field(p => p.UnplattedReferenceId);

            //FieldAsync<SectionBreakdownCodeGraphType, SectionBreakdownCode>
            //(
            //    FieldNames.SectionBreakdownCode,
            //    context =>
            //    {
            //        return dataStore.GetEntityAsync<SectionBreakdownCode>
            //        (
            //            p => p.SectionBreakdownCodeId == context.Source.SectionBreakdownCodeId
            //        );
            //    });
        }
    }
}