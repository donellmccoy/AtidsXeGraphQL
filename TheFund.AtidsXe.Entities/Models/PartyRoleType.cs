using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PARTY_ROLE_TYPE")]
    public partial class PartyRoleType
    {
        public PartyRoleType()
        {
            Party = new HashSet<Party>();
        }

        [Column("PARTY_ROLE_TYPE_ID")]
        public int PartyRoleTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("PartyRoleType")]
        public virtual ICollection<Party> Party { get; set; }
    }
}