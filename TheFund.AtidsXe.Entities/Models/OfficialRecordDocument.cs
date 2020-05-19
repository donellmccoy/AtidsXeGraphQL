using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("OFFICIAL_RECORD_DOCUMENT")]
    public partial class OfficialRecordDocument
    {
        public OfficialRecordDocument()
        {
            CertificationRangeFromOrDocument = new HashSet<CertificationRange>();
            CertificationRangeToOrDocument = new HashSet<CertificationRange>();
            RelatedCaseNumber = new HashSet<RelatedCaseNumber>();
            RelatedOrDocumentRelatedOrDocumentNavigation = new HashSet<RelatedOrDocument>();
            RelatedOrDocumentSearchedOrDocument = new HashSet<RelatedOrDocument>();
            RelatedTaxFolio = new HashSet<RelatedTaxFolio>();
            TitleEventDocument = new HashSet<TitleEventDocument>();
        }

        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }
        [Column("GEOGRAPHIC_LOCALE_ID")]
        public int? GeographicLocaleId { get; set; }

        [ForeignKey("GeographicLocaleId")]
        [InverseProperty("OfficialRecordDocument")]
        public virtual GeographicLocale GeographicLocale { get; set; }
        [InverseProperty("OfficialRecordDocument")]
        public virtual BookPageReference BookPageReference { get; set; }
        [InverseProperty("OfficialRecordDocument")]
        public virtual OrDocumentInformation OrDocumentInformation { get; set; }
        [InverseProperty("OfficialRecordDocument")]
        public virtual PropertyAddress PropertyAddress { get; set; }
        [InverseProperty("OfficialRecordDocument")]
        public virtual YearNumberReference YearNumberReference { get; set; }
        [InverseProperty("FromOrDocument")]
        public virtual ICollection<CertificationRange> CertificationRangeFromOrDocument { get; set; }
        [InverseProperty("ToOrDocument")]
        public virtual ICollection<CertificationRange> CertificationRangeToOrDocument { get; set; }
        [InverseProperty("OfficialRecordDocument")]
        public virtual ICollection<RelatedCaseNumber> RelatedCaseNumber { get; set; }
        [InverseProperty("RelatedOrDocumentNavigation")]
        public virtual ICollection<RelatedOrDocument> RelatedOrDocumentRelatedOrDocumentNavigation { get; set; }
        [InverseProperty("SearchedOrDocument")]
        public virtual ICollection<RelatedOrDocument> RelatedOrDocumentSearchedOrDocument { get; set; }
        [InverseProperty("OfficialRecordDocument")]
        public virtual ICollection<RelatedTaxFolio> RelatedTaxFolio { get; set; }
        [InverseProperty("OfficialRecordDocument")]
        public virtual ICollection<TitleEventDocument> TitleEventDocument { get; set; }
    }
}