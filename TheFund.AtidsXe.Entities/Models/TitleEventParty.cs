using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_PARTY")]
    public partial class TitleEventParty
    {
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("PARTY_ID")]
        public int PartyId { get; set; }

        [ForeignKey("PartyId")]
        [InverseProperty("TitleEventParty")]
        public virtual Party Party { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventParty")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}