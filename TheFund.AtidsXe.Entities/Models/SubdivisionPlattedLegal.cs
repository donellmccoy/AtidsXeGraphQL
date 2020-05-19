using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SUBDIVISION_PLATTED_LEGAL")]
    public partial class SubdivisionPlattedLegal
    {
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
        [Column("PLAT_REFERENCE_ID")]
        public int PlatReferenceId { get; set; }
        [Column("SUBDIVISION_LEVEL_ID")]
        public int SubdivisionLevelId { get; set; }

        [ForeignKey("PlatReferenceId,SubdivisionLevelId")]
        [InverseProperty("SubdivisionPlattedLegal")]
        public virtual PlattedLegal PlattedLegal { get; set; }
        [ForeignKey("SearchId")]
        [InverseProperty("SubdivisionPlattedLegal")]
        public virtual Search Search { get; set; }
    }
}