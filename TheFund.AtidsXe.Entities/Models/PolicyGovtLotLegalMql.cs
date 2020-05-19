using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_GOVT_LOT_LEGAL_MQL")]
    public partial class PolicyGovtLotLegalMql
    {
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Column("GOVERNMENT_LOT_ID")]
        public int GovernmentLotId { get; set; }
        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }

        [ForeignKey("UnplattedReferenceId,GovernmentLotId")]
        [InverseProperty("PolicyGovtLotLegalMql")]
        public virtual GovernmentLotLegal GovernmentLotLegal { get; set; }
        [ForeignKey("PolicyId")]
        [InverseProperty("PolicyGovtLotLegalMql")]
        public virtual Policy Policy { get; set; }
    }
}