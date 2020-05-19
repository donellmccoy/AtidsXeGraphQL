using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class AcreageSectionLegalGraphType : ObjectGraphTypeBase<AcreageSectionLegal>
    {
        public AcreageSectionLegalGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(AcreageSectionLegalGraphType);
            Description = nameof(AcreageSectionLegalGraphType);

            Field(p => p.SectionBreakdownCodeId);
            Field(p => p.UnplattedReferenceId);
            Field(p => p.SearchId);

            Field<SectionLegalGraphType, SectionLegal, SectionLegalCompositeKey>(
                FieldNames.SectionLegal,
                p => new SectionLegalCompositeKey(p.UnplattedReferenceId, p.SectionBreakdownCodeId),
                p => new SectionLegalCompositeKey(p.UnplattedReferenceId, p.SectionBreakdownCodeId));

            Field<SearchGraphType, Search>(
                FieldNames.GovernmentLotLegals,
                p => p.SearchId,
                p => p.SearchId);
        }
    }
}