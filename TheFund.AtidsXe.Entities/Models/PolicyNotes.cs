using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_NOTES")]
    public partial class PolicyNotes
    {
        [Column("POLICY_NOTES_ID")]
        public int PolicyNotesId { get; set; }
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
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

        [ForeignKey("PolicyId")]
        [InverseProperty("PolicyNotes")]
        public virtual Policy Policy { get; set; }
    }
}