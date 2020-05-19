using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PLAT_REFERENCE")]
    public partial class PlatReference
    {
        public PlatReference()
        {
            PlattedLegal = new HashSet<PlattedLegal>();
        }

        [Column("PLAT_REFERENCE_ID")]
        public int PlatReferenceId { get; set; }
        [Required]
        [Column("SOURCE")]
        [StringLength(2)]
        public string Source { get; set; }
        [Required]
        [Column("BOOK")]
        [StringLength(5)]
        public string Book { get; set; }
        [Column("BOOK_SUFFIX")]
        [StringLength(1)]
        public string BookSuffix { get; set; }
        [Required]
        [Column("PAGE")]
        [StringLength(7)]
        public string Page { get; set; }
        [Column("PAGE_SUFFIX")]
        [StringLength(1)]
        public string PageSuffix { get; set; }

        [InverseProperty("PlatReference")]
        public virtual PlatProperties PlatProperties { get; set; }
        [InverseProperty("PlatReference")]
        public virtual ICollection<PlattedLegal> PlattedLegal { get; set; }
    }
}