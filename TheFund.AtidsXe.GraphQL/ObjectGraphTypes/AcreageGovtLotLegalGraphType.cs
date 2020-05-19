using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class AcreageGovtLotLegalGraphType : ObjectGraphTypeBase<AcreageGovtLotLegal>
    {
        public AcreageGovtLotLegalGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(AcreageGovtLotLegalGraphType);
            Description = nameof(AcreageGovtLotLegalGraphType);

            Field(p => p.GovernmentLotId);
            Field(p => p.SearchId);
            Field(p => p.UnplattedReferenceId);

            Field<GovernmentLotLegalGraphType, GovernmentLotLegal, GovernmentLotLegalCompositeKey>(
                FieldNames.GovernmentLotLegals,
                p => new GovernmentLotLegalCompositeKey(p.UnplattedReferenceId, p.GovernmentLotId),
                p => new GovernmentLotLegalCompositeKey(p.UnplattedReferenceId, p.GovernmentLotId));

            Field<SearchGraphType, Search>(
                FieldNames.GovernmentLotLegals,
                p => p.SearchId,
                p => p.SearchId);
        }
    }
}