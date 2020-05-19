using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("WORKSHEET_ITEM")]
    public partial class WorksheetItem
    {
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("WORKSHEET_ID")]
        public int WorksheetId { get; set; }
        [Column("SEQUENCE")]
        public int Sequence { get; set; }

        [ForeignKey("TitleEventId")]
        [InverseProperty("WorksheetItem")]
        public virtual TitleEvent TitleEvent { get; set; }
        [ForeignKey("WorksheetId")]
        [InverseProperty("WorksheetItem")]
        public virtual Worksheet Worksheet { get; set; }
    }
}