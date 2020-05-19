using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("RANGE_DIRECTION_TYPE")]
    public partial class RangeDirectionType
    {
        public RangeDirectionType()
        {
            UnplattedReference = new HashSet<UnplattedReference>();
        }

        [Column("RANGE_DIRECTION_TYPE_ID")]
        public int RangeDirectionTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(16)]
        public string Description { get; set; }

        [InverseProperty("RangeDirectionType")]
        public virtual ICollection<UnplattedReference> UnplattedReference { get; set; }
    }
}