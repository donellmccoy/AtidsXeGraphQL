using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_PLATTED_LEGAL_MQL")]
    public partial class PolicyPlattedLegalMql
    {
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Column("PLAT_REFERENCE_ID")]
        public int PlatReferenceId { get; set; }
        [Column("SUBDIVISION_LEVEL_ID")]
        public int SubdivisionLevelId { get; set; }

        [ForeignKey("PlatReferenceId,SubdivisionLevelId")]
        [InverseProperty("PolicyPlattedLegalMql")]
        public virtual PlattedLegal PlattedLegal { get; set; }
        [ForeignKey("PolicyId")]
        [InverseProperty("PolicyPlattedLegalMql")]
        public virtual Policy Policy { get; set; }
    }
}