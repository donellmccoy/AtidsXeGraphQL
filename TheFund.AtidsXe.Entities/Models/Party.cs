using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PARTY")]
    public partial class Party
    {
        public Party()
        {
            PartyLegalEntityName = new HashSet<PartyLegalEntityName>();
            TitleEventParty = new HashSet<TitleEventParty>();
        }

        [Column("PARTY_ID")]
        public int PartyId { get; set; }
        [Column("PARTY_ROLE_TYPE_ID")]
        public int PartyRoleTypeId { get; set; }
        [Required]
        [Column("UNPARSED_PARTY")]
        [StringLength(256)]
        public string UnparsedParty { get; set; }

        [ForeignKey("PartyRoleTypeId")]
        [InverseProperty("Party")]
        public virtual PartyRoleType PartyRoleType { get; set; }
        [InverseProperty("Party")]
        public virtual ICollection<PartyLegalEntityName> PartyLegalEntityName { get; set; }
        [InverseProperty("Party")]
        public virtual ICollection<TitleEventParty> TitleEventParty { get; set; }
    }
}