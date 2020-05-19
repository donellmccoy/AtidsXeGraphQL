using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_NOTES")]
    public partial class TitleEventNotes
    {
        [Column("TITLE_EVENT_NOTES_ID")]
        public int TitleEventNotesId { get; set; }
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Required]
        [Column("USER_ID")]
        [StringLength(30)]
        public string UserId { get; set; }
        [Column("TIME_STAMP", TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }
        [Required]
        [Column("MESSAGE")]
        [StringLength(1024)]
        public string Message { get; set; }

        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventNotes")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}