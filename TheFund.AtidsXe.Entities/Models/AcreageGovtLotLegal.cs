using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("ACREAGE_GOVT_LOT_LEGAL")]
    public partial class AcreageGovtLotLegal
    {
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
        [Column("GOVERNMENT_LOT_ID")]
        public int GovernmentLotId { get; set; }
        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }

        [ForeignKey("UnplattedReferenceId,GovernmentLotId")]
        [InverseProperty("AcreageGovtLotLegal")]
        public virtual GovernmentLotLegal GovernmentLotLegal { get; set; }
        [ForeignKey("SearchId")]
        [InverseProperty("AcreageGovtLotLegal")]
        public virtual Search Search { get; set; }
    }
}