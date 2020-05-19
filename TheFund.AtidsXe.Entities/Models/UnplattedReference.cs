using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("UNPLATTED_REFERENCE")]
    public partial class UnplattedReference
    {
        public UnplattedReference()
        {
            GovernmentLotLegal = new HashSet<GovernmentLotLegal>();
            SectionLegal = new HashSet<SectionLegal>();
        }

        [Column("UNPLATTED_REFERENCE_ID")]
        public int UnplattedReferenceId { get; set; }
        [Required]
        [Column("MERIDIAN")]
        [StringLength(50)]
        public string Meridian { get; set; }
        [Required]
        [Column("RANGE")]
        [StringLength(50)]
        public string Range { get; set; }
        [Column("RANGE_DIRECTION_TYPE_ID")]
        public int RangeDirectionTypeId { get; set; }
        [Required]
        [Column("TOWNSHIP")]
        [StringLength(50)]
        public string Township { get; set; }
        [Column("TOWNSHIP_DIRECTION_TYPE_ID")]
        public int TownshipDirectionTypeId { get; set; }
        [Required]
        [Column("SECTION")]
        [StringLength(50)]
        public string Section { get; set; }
        [Column("BREAKDOWN_CODE_TYPE_ID")]
        public int BreakdownCodeTypeId { get; set; }

        [ForeignKey("BreakdownCodeTypeId")]
        [InverseProperty("UnplattedReference")]
        public virtual BreakdownCodeType BreakdownCodeType { get; set; }
        [ForeignKey("RangeDirectionTypeId")]
        [InverseProperty("UnplattedReference")]
        public virtual RangeDirectionType RangeDirectionType { get; set; }
        [ForeignKey("TownshipDirectionTypeId")]
        [InverseProperty("UnplattedReference")]
        public virtual TownshipDirectionType TownshipDirectionType { get; set; }
        [InverseProperty("UnplattedReference")]
        public virtual ICollection<GovernmentLotLegal> GovernmentLotLegal { get; set; }
        [InverseProperty("UnplattedReference")]
        public virtual ICollection<SectionLegal> SectionLegal { get; set; }
    }
}