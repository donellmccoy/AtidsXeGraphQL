using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("BREAKDOWN_CODE_TYPE")]
    public partial class BreakdownCodeType
    {
        public BreakdownCodeType()
        {
            UnplattedReference = new HashSet<UnplattedReference>();
        }

        [Column("BREAKDOWN_CODE_TYPE_ID")]
        public int BreakdownCodeTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(32)]
        public string Description { get; set; }

        [InverseProperty("BreakdownCodeType")]
        public virtual ICollection<UnplattedReference> UnplattedReference { get; set; }
    }
}