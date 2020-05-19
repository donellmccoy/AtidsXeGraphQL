using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("ACREAGE_SECTION_LEGAL")]
    public partial class AcreageSectionLegal
    {
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
        [Column("SECTION_BREAKDOWN_CODE_ID")]
        public int SectionBreakdownCodeId { get; set; }
        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }

        [ForeignKey("SearchId")]
        [InverseProperty("AcreageSectionLegal")]
        public virtual Search Search { get; set; }
        [ForeignKey("SectionBreakdownCodeId,UnplattedReferenceId")]
        [InverseProperty("AcreageSectionLegal")]
        public virtual SectionLegal SectionLegal { get; set; }
    }
}