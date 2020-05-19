using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_DOCUMENT")]
    public partial class TitleEventDocument
    {
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }

        [ForeignKey("OfficialRecordDocumentId")]
        [InverseProperty("TitleEventDocument")]
        public virtual OfficialRecordDocument OfficialRecordDocument { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventDocument")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}