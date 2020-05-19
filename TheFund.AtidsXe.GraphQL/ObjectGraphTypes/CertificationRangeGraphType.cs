using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class CertificationRangeGraphType : ObjectGraphTypeBase<CertificationRange>
    {
        public CertificationRangeGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(CertificationRangeGraphType);
            Description = nameof(CertificationRangeGraphType);

            Field(p => p.ToOrDocumentId);
            Field(p => p.CertificationRangeId);
            Field(p => p.FromDate);
            Field(p => p.FromOrDocumentId);
            Field(p => p.ToDate);

            //FromOrDocument
            //ToOrDocument
            //list:SearchGeographicCertRange
            //list:SearchGiCertRange
            //list:SearchGrantorCertRange
        }
    }
}