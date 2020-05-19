using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_RESTRICTION_TYPE")]
    public partial class PolicyRestrictionType
    {
        public PolicyRestrictionType()
        {
            Policy = new HashSet<Policy>();
        }

        [Column("POLICY_RESTRICTION_TYPE_ID")]
        public int PolicyRestrictionTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(25)]
        public string Description { get; set; }

        [InverseProperty("PolicyRestrictionType")]
        public virtual ICollection<Policy> Policy { get; set; }
    }
}