using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_GOVT_LOT_LEGAL_MQL")]
    public partial class TitleEventGovtLotLegalMql
    {
        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }
        [Column("GOVERNMENT_LOT_ID")]
        public int GovernmentLotId { get; set; }
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }

        [ForeignKey("UnplattedReferenceId,GovernmentLotId")]
        [InverseProperty("TitleEventGovtLotLegalMql")]
        public virtual GovernmentLotLegal GovernmentLotLegal { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventGovtLotLegalMql")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}