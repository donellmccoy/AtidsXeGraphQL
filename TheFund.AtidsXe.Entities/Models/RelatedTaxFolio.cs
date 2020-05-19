using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("RELATED_TAX_FOLIO")]
    public partial class RelatedTaxFolio
    {
        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }
        [Column("TAX_FOLIO_REFERENCE_ID")]
        public int TaxFolioReferenceId { get; set; }

        [ForeignKey("OfficialRecordDocumentId")]
        [InverseProperty("RelatedTaxFolio")]
        public virtual OfficialRecordDocument OfficialRecordDocument { get; set; }
        [ForeignKey("TaxFolioReferenceId")]
        [InverseProperty("RelatedTaxFolio")]
        public virtual TaxFolioReference TaxFolioReference { get; set; }
    }
}