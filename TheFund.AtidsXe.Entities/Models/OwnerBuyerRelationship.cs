using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("OWNER_BUYER_RELATIONSHIP")]
    public partial class OwnerBuyerRelationship
    {
        public OwnerBuyerRelationship()
        {
            NameSearchParameters = new HashSet<NameSearchParameters>();
        }

        [Column("OWNER_BUYER_RELATIONSHIP_ID")]
        public int OwnerBuyerRelationshipId { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("OwnerBuyerRelationship")]
        public virtual ICollection<NameSearchParameters> NameSearchParameters { get; set; }
    }
}