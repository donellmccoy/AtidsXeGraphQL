using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TOWNSHIP_DIRECTION_TYPE")]
    public partial class TownshipDirectionType
    {
        public TownshipDirectionType()
        {
            UnplattedReference = new HashSet<UnplattedReference>();
        }

        [Column("TOWNSHIP_DIRECTION_TYPE_ID")]
        public int TownshipDirectionTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(16)]
        public string Description { get; set; }

        [InverseProperty("TownshipDirectionType")]
        public virtual ICollection<UnplattedReference> UnplattedReference { get; set; }
    }
}