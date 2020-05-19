using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SearchGraphType : ObjectGraphTypeBase<Search>
    {
        public SearchGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(SearchGraphType);
            Description = nameof(SearchGraphType);

            Field(entity => entity.FileReferenceId);
            Field(x => x.DateOfSearch);
            Field(x => x.GeographicCertRangeId, true);
            Field(x => x.GiCertRangeId, true);
            Field<IntGraphType>(FieldNames.Hidden, context => context.Source.Hidden);
            Field(x => x.GeographicLocaleId);
            Field(x => x.GrantorCertRangeId, true);
            Field<IntGraphType>(FieldNames.InclMortgageeShortForm, context => context.Source.InclMortgageeShortForm);
            Field<StringGraphType>(FieldNames.InstrumentFilters, context => context.Source.InstrumentFilters.TrimIfNotNull());
            Field<IntGraphType>(FieldNames.LrsSearch, context => context.Source.LrsSearch);
            Field(x => x.ParentSearchId, true);
            Field(x => x.SearchFromDate);
            Field(x => x.SearchId);
            Field<StringGraphType>(FieldNames.SearchReference, context => context.Source.SearchReference.TrimIfNotNull());
            Field(x => x.SearchStatusId, true);
            Field(x => x.SearchTypeId);
            Field(x => x.SearchThruDate);

            Field<CertificationRangeGraphType, CertificationRange>(
                FieldNames.GeographicCertRange,
                p => p.GeographicCertRangeId ?? 0,
                p => p.CertificationRangeId);

            Field<CertificationRangeGraphType, CertificationRange>(
                FieldNames.GiCertRange,
                p => p.GiCertRangeId ?? 0,
                p => p.CertificationRangeId);

            Field<CertificationRangeGraphType, CertificationRange>(
                FieldNames.GrantorCertRange,
                p => p.GrantorCertRangeId ?? 0,
                p => p.CertificationRangeId);

            Field<SearchStatusGraphType, SearchStatus>(
                FieldNames.SearchStatus,
                p => p.SearchStatusId ?? 0,
                p => p.SearchStatusId);

            Field<NameSearchParametersGraphType, NameSearchParameters>(
                FieldNames.NameSearchParameters,
                p => p.SearchId,
                p => p.SearchId);

            Field<PolicyTitleStatusReportGraphType, PolicyTitleStatusReport>(
                FieldNames.PolicyTitleStatusReport,
                p => p.SearchId,
                p => p.SearchId);

            Field<SearchTypeGraphType, SearchType>(
                FieldNames.SearchType,
                p => p.SearchTypeId,
                p => p.SearchTypeId);

            Field<GeographicLocaleGraphType, GeographicLocale>(
                FieldNames.GeographicLocale,
                p => p.GeographicLocaleId,
                p => p.GeographicLocaleId);

            FieldListAsync<TitleEventSearchGraphType, TitleEventSearch>(
                FieldNames.TitleEventSearches,
                p => p.SearchId,
                p => p.SearchId);

            FieldListAsync<SubdivisionPlattedLegalGraphType, SubdivisionPlattedLegal>(
                FieldNames.SubdivisionPlattedLegals,
                p => p.SearchId,
                p => p.SearchId);

            FieldListAsync<AcreageSectionLegalGraphType, AcreageSectionLegal>(
                FieldNames.AcreageSectionLegals,
                p => p.SearchId,
                p => p.SearchId);

            FieldListAsync<AcreageGovtLotLegalGraphType, AcreageGovtLotLegal>(
                FieldNames.AcreageGovtLotLegals,
                p => p.SearchId,
                p => p.SearchId);

            FieldListAsync<SearchWarningGraphType, SearchWarning>(
                FieldNames.SearchWarnings,
                p => p.SearchId,
                p => p.SearchId);

            FieldListAsync<PolicySearchGraphType, PolicySearch>(
                FieldNames.PolicySearches,
                p => p.SearchId,
                p => p.SearchId);

            FieldListAsync<SearchNotesGraphType, SearchNotes>(
                FieldNames.SearchNotes,
                p => p.SearchId,
                p => p.SearchId);

            FieldListAsync<SearchGraphType, Search>(
                FieldNames.ParentSearches,
                p => p.SearchId,
                p => p.SearchId);
        }
    }
}