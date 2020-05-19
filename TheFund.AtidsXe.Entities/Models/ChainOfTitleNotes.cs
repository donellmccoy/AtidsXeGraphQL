using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("CHAIN_OF_TITLE_NOTES")]
    public partial class ChainOfTitleNotes
    {
        [Column("CHAIN_OF_TITLE_NOTES_ID")]
        public int ChainOfTitleNotesId { get; set; }
        [Column("CHAIN_OF_TITLE_ID")]
        public int ChainOfTitleId { get; set; }
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

        [ForeignKey("ChainOfTitleId")]
        [InverseProperty("ChainOfTitleNotes")]
        public virtual ChainOfTitle ChainOfTitle { get; set; }
    }
}