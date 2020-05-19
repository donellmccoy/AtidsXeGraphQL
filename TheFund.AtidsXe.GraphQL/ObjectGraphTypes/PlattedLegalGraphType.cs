using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PlattedLegalGraphType : ObjectGraphTypeBase<PlattedLegal>
    {
        public PlattedLegalGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(PlattedLegalGraphType);
            Description = nameof(PlattedLegalGraphType);

            Field(p => p.PlatReferenceId);
            Field(p => p.SubdivisionLevelId);

            //Field<PlatReferenceGraphType, PlatReference>(
            //             FieldNames.PlatReference,
            //             p => p.PlatReferenceId,
            //             p => p.PlatReferenceId);

            //Field<SubdivisionLevelsGraphType, SubdivisionLevels>(
            //             FieldNames.SubdivisionLevels,
            //             p => p.SubdivisionLevelId,
            //             p => p.SubdivisionLevelId);

            //FieldListAsync<SubdivisionPlattedLegalGraphType, SubdivisionPlattedLegal, SubdivisionPlattedLegalCompositeKey>(
            //   FieldNames.SubdivisionPlattedLegals,
            //   p => new SubdivisionPlattedLegalCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId),
            //   p => new SubdivisionPlattedLegalCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId));

            //FieldListAsync<PolicyPlattedLegalMqlGraphType, PolicyPlattedLegalMql, PolicyPlattedLegalMqlCompositeKey>(
            //    FieldNames.PolicyPlattedLegalMqls,
            //    p => new PolicyPlattedLegalMqlCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId),
            //    p => new PolicyPlattedLegalMqlCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId));

            //FieldListAsync<TitleEventPlattedLegalMqlGraphType, TitleEventPlattedLegalMql, TitleEventPlattedLegalMqlCompositeKey>(
            //             FieldNames.TitleEventPlattedLegalMqls,
            //             p => new TitleEventPlattedLegalMqlCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId),
            //             p => new TitleEventPlattedLegalMqlCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId));
        }
    }
}
