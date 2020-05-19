using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("GOVERNMENT_LOT_LEGAL")]
    public partial class GovernmentLotLegal
    {
        public GovernmentLotLegal()
        {
            AcreageGovtLotLegal = new HashSet<AcreageGovtLotLegal>();
            PolicyGovtLotLegalMql = new HashSet<PolicyGovtLotLegalMql>();
            TitleEventGovtLotLegalMql = new HashSet<TitleEventGovtLotLegalMql>();
        }

        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }
        [Column("GOVERNMENT_LOT_ID")]
        public int GovernmentLotId { get; set; }

        [ForeignKey("GovernmentLotId")]
        [InverseProperty("GovernmentLotLegal")]
        public virtual GovernmentLot GovernmentLot { get; set; }
        [ForeignKey("UnplattedReferenceId")]
        [InverseProperty("GovernmentLotLegal")]
        public virtual UnplattedReference UnplattedReference { get; set; }
        [InverseProperty("GovernmentLotLegal")]
        public virtual ICollection<AcreageGovtLotLegal> AcreageGovtLotLegal { get; set; }
        [InverseProperty("GovernmentLotLegal")]
        public virtual ICollection<PolicyGovtLotLegalMql> PolicyGovtLotLegalMql { get; set; }
        [InverseProperty("GovernmentLotLegal")]
        public virtual ICollection<TitleEventGovtLotLegalMql> TitleEventGovtLotLegalMql { get; set; }
    }
}