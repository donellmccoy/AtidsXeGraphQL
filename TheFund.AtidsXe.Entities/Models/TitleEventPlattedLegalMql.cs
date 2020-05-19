using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_PLATTED_LEGAL_MQL")]
    public partial class TitleEventPlattedLegalMql
    {
        [Column("SUBDIVISION_LEVEL_ID")]
        public int SubdivisionLevelId { get; set; }
        [Column("PLAT_REFERENCE_ID")]
        public int PlatReferenceId { get; set; }
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }

        [ForeignKey("PlatReferenceId,SubdivisionLevelId")]
        [InverseProperty("TitleEventPlattedLegalMql")]
        public virtual PlattedLegal PlattedLegal { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventPlattedLegalMql")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}