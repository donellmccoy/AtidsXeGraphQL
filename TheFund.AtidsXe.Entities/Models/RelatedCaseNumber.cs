using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("RELATED_CASE_NUMBER")]
    public partial class RelatedCaseNumber
    {
        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }
        [Column("CASE_NUMBER_REFERENCE_ID")]
        public int CaseNumberReferenceId { get; set; }

        [ForeignKey("CaseNumberReferenceId")]
        [InverseProperty("RelatedCaseNumber")]
        public virtual CaseNumberReference CaseNumberReference { get; set; }
        [ForeignKey("OfficialRecordDocumentId")]
        [InverseProperty("RelatedCaseNumber")]
        public virtual OfficialRecordDocument OfficialRecordDocument { get; set; }
    }
}