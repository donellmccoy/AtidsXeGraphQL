using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("BOOK_PAGE_REFERENCE")]
    public partial class BookPageReference
    {
        [Key]
        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }
        [Required]
        [Column("SOURCE")]
        [StringLength(2)]
        public string Source { get; set; }
        [Required]
        [Column("BOOK")]
        [StringLength(5)]
        public string Book { get; set; }
        [Column("BOOK_SUFFIX")]
        [StringLength(1)]
        public string BookSuffix { get; set; }
        [Required]
        [Column("PAGE")]
        [StringLength(5)]
        public string Page { get; set; }
        [Column("PAGE_SUFFIX")]
        [StringLength(1)]
        public string PageSuffix { get; set; }

        [ForeignKey("OfficialRecordDocumentId")]
        [InverseProperty("BookPageReference")]
        public virtual OfficialRecordDocument OfficialRecordDocument { get; set; }
    }
}