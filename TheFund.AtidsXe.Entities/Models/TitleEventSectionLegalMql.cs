using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_SECTION_LEGAL_MQL")]
    public partial class TitleEventSectionLegalMql
    {
        [Column("SECTION_BREAKDOWN_CODE_ID")]
        public int SectionBreakdownCodeId { get; set; }
        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }

        [ForeignKey("SectionBreakdownCodeId,UnplattedReferenceId")]
        [InverseProperty("TitleEventSectionLegalMql")]
        public virtual SectionLegal SectionLegal { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventSectionLegalMql")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}