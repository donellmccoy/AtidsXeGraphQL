using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class CaseNumberReferenceGraphType : ObjectGraphTypeBase<CaseNumberReference>
    {
        public CaseNumberReferenceGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(CaseNumberReferenceGraphType);
            Description = nameof(CaseNumberReferenceGraphType);

            Field(p => p.CaseNumberReferenceId);
            Field(p => p.GeographicLocaleId);
            Field(p => p.RecordingNumber);
            Field(p => p.SeriesCode);
            Field(p => p.Source);
            Field(p => p.Suffix);
            Field<GeographicLocaleGraphType, GeographicLocale>(
                FieldNames.GeographicLocale,
                p => p.GeographicLocaleId ?? 0,
                p => p.GeographicLocaleId);
        }
    }
}