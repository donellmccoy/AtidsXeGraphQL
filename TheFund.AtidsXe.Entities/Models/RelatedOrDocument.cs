using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("RELATED_OR_DOCUMENT")]
    public partial class RelatedOrDocument
    {
        [Column("SEARCHED_OR_DOCUMENT_ID")]
        public int SearchedOrDocumentId { get; set; }
        [Column("RELATED_OR_DOCUMENT_ID")]
        public int RelatedOrDocumentId { get; set; }

        [ForeignKey("RelatedOrDocumentId")]
        [InverseProperty("RelatedOrDocumentRelatedOrDocumentNavigation")]
        public virtual OfficialRecordDocument RelatedOrDocumentNavigation { get; set; }
        [ForeignKey("SearchedOrDocumentId")]
        [InverseProperty("RelatedOrDocumentSearchedOrDocument")]
        public virtual OfficialRecordDocument SearchedOrDocument { get; set; }
    }
}