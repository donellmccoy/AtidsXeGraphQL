using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SECTION_LEGAL")]
    public partial class SectionLegal
    {
        public SectionLegal()
        {
            AcreageSectionLegal = new HashSet<AcreageSectionLegal>();
            PolicySectionLegalMql = new HashSet<PolicySectionLegalMql>();
            TitleEventSectionLegalMql = new HashSet<TitleEventSectionLegalMql>();
        }

        [Column("SECTION_BREAKDOWN_CODE_ID")]
        public int SectionBreakdownCodeId { get; set; }
        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }

        [ForeignKey("SectionBreakdownCodeId")]
        [InverseProperty("SectionLegal")]
        public virtual SectionBreakdownCode SectionBreakdownCode { get; set; }
        [ForeignKey("UnplattedReferenceId")]
        [InverseProperty("SectionLegal")]
        public virtual UnplattedReference UnplattedReference { get; set; }
        [InverseProperty("SectionLegal")]
        public virtual ICollection<AcreageSectionLegal> AcreageSectionLegal { get; set; }
        [InverseProperty("SectionLegal")]
        public virtual ICollection<PolicySectionLegalMql> PolicySectionLegalMql { get; set; }
        [InverseProperty("SectionLegal")]
        public virtual ICollection<TitleEventSectionLegalMql> TitleEventSectionLegalMql { get; set; }
    }
}