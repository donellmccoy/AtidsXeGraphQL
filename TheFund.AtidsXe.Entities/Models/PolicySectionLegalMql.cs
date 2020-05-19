using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_SECTION_LEGAL_MQL")]
    public partial class PolicySectionLegalMql
    {
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }
        [Column("SECTION_BREAKDOWN_CODE_ID")]
        public int SectionBreakdownCodeId { get; set; }

        [ForeignKey("PolicyId")]
        [InverseProperty("PolicySectionLegalMql")]
        public virtual Policy Policy { get; set; }
        [ForeignKey("SectionBreakdownCodeId,UnplattedReferenceId")]
        [InverseProperty("PolicySectionLegalMql")]
        public virtual SectionLegal SectionLegal { get; set; }
    }
}