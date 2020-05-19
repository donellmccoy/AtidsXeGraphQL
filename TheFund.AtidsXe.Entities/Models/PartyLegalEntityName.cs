using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PARTY_LEGAL_ENTITY_NAME")]
    public partial class PartyLegalEntityName
    {
        [Column("PARTY_ID")]
        public int PartyId { get; set; }
        [Column("LEGAL_ENTITY_NAME_ID")]
        public int LegalEntityNameId { get; set; }

        [ForeignKey("LegalEntityNameId")]
        [InverseProperty("PartyLegalEntityName")]
        public virtual LegalEntityName LegalEntityName { get; set; }
        [ForeignKey("PartyId")]
        [InverseProperty("PartyLegalEntityName")]
        public virtual Party Party { get; set; }
    }
}