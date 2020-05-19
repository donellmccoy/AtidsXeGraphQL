using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SEARCH")]
    public partial class Search
    {
        public Search()
        {
            AcreageGovtLotLegal = new HashSet<AcreageGovtLotLegal>();
            AcreageSectionLegal = new HashSet<AcreageSectionLegal>();
            ChainOfTitleSearch = new HashSet<ChainOfTitleSearch>();
            InverseParentSearch = new HashSet<Search>();
            PolicySearch = new HashSet<PolicySearch>();
            SearchNotes = new HashSet<SearchNotes>();
            SearchWarning = new HashSet<SearchWarning>();
            SubdivisionPlattedLegal = new HashSet<SubdivisionPlattedLegal>();
            TitleEventSearch = new HashSet<TitleEventSearch>();
        }

        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
        [Column("FILE_REFERENCE_ID")]
        public int FileReferenceId { get; set; }
        [Required]
        [Column("SEARCH_REFERENCE")]
        [StringLength(256)]
        public string SearchReference { get; set; }
        [Column("DATE_OF_SEARCH", TypeName = "datetime")]
        public DateTime DateOfSearch { get; set; }
        [Column("SEARCH_FROM_DATE", TypeName = "datetime")]
        public DateTime SearchFromDate { get; set; }
        [Column("SEARCH_THRU_DATE", TypeName = "datetime")]
        public DateTime SearchThruDate { get; set; }
        [Column("SEARCH_TYPE_ID")]
        public int SearchTypeId { get; set; }
        [Column("GEOGRAPHIC_LOCALE_ID")]
        public int GeographicLocaleId { get; set; }
        [Column("GEOGRAPHIC_CERT_RANGE_ID")]
        public int? GeographicCertRangeId { get; set; }
        [Column("GI_CERT_RANGE_ID")]
        public int? GiCertRangeId { get; set; }
        [Column("GRANTOR_CERT_RANGE_ID")]
        public int? GrantorCertRangeId { get; set; }
        [Column("PARENT_SEARCH_ID")]
        public int? ParentSearchId { get; set; }
        [Column("SEARCH_STATUS_ID")]
        public int? SearchStatusId { get; set; }
        [Column("INSTRUMENT_FILTERS")]
        [StringLength(150)]
        public string InstrumentFilters { get; set; }
        [Column("LRS_SEARCH")]
        public byte? LrsSearch { get; set; }
        [Column("INCL_MORTGAGEE_SHORT_FORM")]
        public byte? InclMortgageeShortForm { get; set; }
        [Column("HIDDEN")]
        public byte? Hidden { get; set; }

        [ForeignKey("FileReferenceId")]
        [InverseProperty("Search")]
        public virtual FileReference FileReference { get; set; }
        [ForeignKey("GeographicCertRangeId")]
        [InverseProperty("SearchGeographicCertRange")]
        public virtual CertificationRange GeographicCertRange { get; set; }
        [ForeignKey("GeographicLocaleId")]
        [InverseProperty("Search")]
        public virtual GeographicLocale GeographicLocale { get; set; }
        [ForeignKey("GiCertRangeId")]
        [InverseProperty("SearchGiCertRange")]
        public virtual CertificationRange GiCertRange { get; set; }
        [ForeignKey("GrantorCertRangeId")]
        [InverseProperty("SearchGrantorCertRange")]
        public virtual CertificationRange GrantorCertRange { get; set; }
        [ForeignKey("ParentSearchId")]
        [InverseProperty("InverseParentSearch")]
        public virtual Search ParentSearch { get; set; }
        [ForeignKey("SearchStatusId")]
        [InverseProperty("Search")]
        public virtual SearchStatus SearchStatus { get; set; }
        [ForeignKey("SearchTypeId")]
        [InverseProperty("Search")]
        public virtual SearchType SearchType { get; set; }
        [InverseProperty("Search")]
        public virtual NameSearchParameters NameSearchParameters { get; set; }
        [InverseProperty("Search")]
        public virtual PolicyTitleStatusReport PolicyTitleStatusReport { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<AcreageGovtLotLegal> AcreageGovtLotLegal { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<AcreageSectionLegal> AcreageSectionLegal { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<ChainOfTitleSearch> ChainOfTitleSearch { get; set; }
        [InverseProperty("ParentSearch")]
        public virtual ICollection<Search> InverseParentSearch { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<PolicySearch> PolicySearch { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<SearchNotes> SearchNotes { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<SearchWarning> SearchWarning { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<SubdivisionPlattedLegal> SubdivisionPlattedLegal { get; set; }
        [InverseProperty("Search")]
        public virtual ICollection<TitleEventSearch> TitleEventSearch { get; set; }
    }
}