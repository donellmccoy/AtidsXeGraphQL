using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PLATTED_LEGAL")]
    public partial class PlattedLegal
    {
        public PlattedLegal()
        {
            PolicyPlattedLegalMql = new HashSet<PolicyPlattedLegalMql>();
            SubdivisionPlattedLegal = new HashSet<SubdivisionPlattedLegal>();
            TitleEventPlattedLegalMql = new HashSet<TitleEventPlattedLegalMql>();
        }

        [Column("PLAT_REFERENCE_ID")]
        public int PlatReferenceId { get; set; }
        [Column("SUBDIVISION_LEVEL_ID")]
        public int SubdivisionLevelId { get; set; }

        [ForeignKey("PlatReferenceId")]
        [InverseProperty("PlattedLegal")]
        public virtual PlatReference PlatReference { get; set; }
        [ForeignKey("SubdivisionLevelId")]
        [InverseProperty("PlattedLegal")]
        public virtual SubdivisionLevels SubdivisionLevel { get; set; }
        [InverseProperty("PlattedLegal")]
        public virtual ICollection<PolicyPlattedLegalMql> PolicyPlattedLegalMql { get; set; }
        [InverseProperty("PlattedLegal")]
        public virtual ICollection<SubdivisionPlattedLegal> SubdivisionPlattedLegal { get; set; }
        [InverseProperty("PlattedLegal")]
        public virtual ICollection<TitleEventPlattedLegalMql> TitleEventPlattedLegalMql { get; set; }
    }
}