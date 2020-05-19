using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TAX_FOLIO_REFERENCE")]
    public partial class TaxFolioReference
    {
        public TaxFolioReference()
        {
            RelatedTaxFolio = new HashSet<RelatedTaxFolio>();
        }

        [Column("TAX_FOLIO_REFERENCE_ID")]
        public int TaxFolioReferenceId { get; set; }
        [Required]
        [Column("FOLIO_NUMBER")]
        [StringLength(50)]
        public string FolioNumber { get; set; }
        [Column("GEOGRAPHIC_LOCALE_ID")]
        public int? GeographicLocaleId { get; set; }

        [ForeignKey("GeographicLocaleId")]
        [InverseProperty("TaxFolioReference")]
        public virtual GeographicLocale GeographicLocale { get; set; }
        [InverseProperty("TaxFolioReference")]
        public virtual ICollection<RelatedTaxFolio> RelatedTaxFolio { get; set; }
    }
}