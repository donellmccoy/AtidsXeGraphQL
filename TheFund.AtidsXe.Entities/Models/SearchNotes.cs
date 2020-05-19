using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SEARCH_NOTES")]
    public partial class SearchNotes
    {
        [Column("SEARCH_NOTES_ID")]
        public int SearchNotesId { get; set; }
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
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

        [ForeignKey("SearchId")]
        [InverseProperty("SearchNotes")]
        public virtual Search Search { get; set; }
    }
}