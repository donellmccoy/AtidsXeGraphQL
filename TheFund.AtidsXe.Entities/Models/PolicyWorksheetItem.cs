using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_WORKSHEET_ITEM")]
    public partial class PolicyWorksheetItem
    {
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Column("WORKSHEET_ID")]
        public int WorksheetId { get; set; }
        [Column("SEQUENCE")]
        public int Sequence { get; set; }

        [ForeignKey("PolicyId")]
        [InverseProperty("PolicyWorksheetItem")]
        public virtual Policy Policy { get; set; }
        [ForeignKey("WorksheetId")]
        [InverseProperty("PolicyWorksheetItem")]
        public virtual Worksheet Worksheet { get; set; }
    }
}