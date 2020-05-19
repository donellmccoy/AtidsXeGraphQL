using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("GEOGRAPHIC_LOCALE")]
    public partial class GeographicLocale
    {
        public GeographicLocale()
        {
            CaseNumberReference = new HashSet<CaseNumberReference>();
            FileReference = new HashSet<FileReference>();
            InverseParentGeographicLocale = new HashSet<GeographicLocale>();
            OfficialRecordDocument = new HashSet<OfficialRecordDocument>();
            PolicyInsuredDocument = new HashSet<PolicyInsuredDocument>();
            Search = new HashSet<Search>();
            TaxFolioReference = new HashSet<TaxFolioReference>();
        }

        [Column("GEOGRAPHIC_LOCALE_ID")]
        public int GeographicLocaleId { get; set; }
        [Required]
        [Column("LOCALE_NAME")]
        [StringLength(200)]
        public string LocaleName { get; set; }
        [Column("LOCALE_ABBREVIATION")]
        [StringLength(50)]
        public string LocaleAbbreviation { get; set; }
        [Column("GEOGRAPHIC_LOCALE_TYPE_ID")]
        public int GeographicLocaleTypeId { get; set; }
        [Column("PARENT_GEOGRAPHIC_LOCALE_ID")]
        public int? ParentGeographicLocaleId { get; set; }

        [ForeignKey("GeographicLocaleTypeId")]
        [InverseProperty("GeographicLocale")]
        public virtual GeographicLocaleType GeographicLocaleType { get; set; }
        [ForeignKey("ParentGeographicLocaleId")]
        [InverseProperty("InverseParentGeographicLocale")]
        public virtual GeographicLocale ParentGeographicLocale { get; set; }
        [InverseProperty("GeographicLocale")]
        public virtual ICollection<CaseNumberReference> CaseNumberReference { get; set; }
        [InverseProperty("DefaultGeographicLocale")]
        public virtual ICollection<FileReference> FileReference { get; set; }
        [InverseProperty("ParentGeographicLocale")]
        public virtual ICollection<GeographicLocale> InverseParentGeographicLocale { get; set; }
        [InverseProperty("GeographicLocale")]
        public virtual ICollection<OfficialRecordDocument> OfficialRecordDocument { get; set; }
        [InverseProperty("GeographicLocale")]
        public virtual ICollection<PolicyInsuredDocument> PolicyInsuredDocument { get; set; }
        [InverseProperty("GeographicLocale")]
        public virtual ICollection<Search> Search { get; set; }
        [InverseProperty("GeographicLocale")]
        public virtual ICollection<TaxFolioReference> TaxFolioReference { get; set; }
    }
}