using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_LEGAL_ENTITY_MQL")]
    public partial class TitleEventLegalEntityMql
    {
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("LEGAL_ENTITY_NAME_ID")]
        public int LegalEntityNameId { get; set; }

        [ForeignKey("LegalEntityNameId")]
        [InverseProperty("TitleEventLegalEntityMql")]
        public virtual LegalEntityName LegalEntityName { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventLegalEntityMql")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}