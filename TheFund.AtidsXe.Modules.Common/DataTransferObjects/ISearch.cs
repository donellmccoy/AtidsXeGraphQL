using System;
using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    public interface ISearch
    {
        int SearchId { get; set; }
        int FileReferenceId { get; set; }
        string SearchReference { get; set; }
        DateTime DateOfSearch { get; set; }
        DateTime SearchFromDate { get; set; }
        DateTime SearchThruDate { get; set; }
        int SearchTypeId { get; set; }
        int GeographicLocaleId { get; set; }
        int? GeographicCertRangeId { get; set; }
        int? GiCertRangeId { get; set; }
        int? GrantorCertRangeId { get; set; }
        int? ParentSearchId { get; set; }
        int? SearchStatusId { get; set; }
        string InstrumentFilters { get; set; }
        byte? LrsSearch { get; set; }
        byte? InclMortgageeShortForm { get; set; }
        byte? Hidden { get; set; }
        List<TitleEventSearch> TitleEventSearches { get; set; }
        bool LrsSearchBool { get; }
        bool InclMortgageeShortFormBool { get; }
        bool IsHiddenBool { get; }
        bool HasTitleEventSearches { get; }
        bool HasSubdivisionPlattedLegals { get; }
    }
}