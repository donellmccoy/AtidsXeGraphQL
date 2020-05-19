using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SUBDIVISION_LEVELS")]
    public partial class SubdivisionLevels
    {
        public SubdivisionLevels()
        {
            PlattedLegal = new HashSet<PlattedLegal>();
        }

        [Key]
        [Column("SUBDIVISION_LEVEL_ID")]
        public int SubdivisionLevelId { get; set; }
        [Required]
        [Column("LEVEL1")]
        [StringLength(6)]
        public string Level1 { get; set; }
        [Required]
        [Column("LEVEL2")]
        [StringLength(6)]
        public string Level2 { get; set; }
        [Required]
        [Column("LEVEL3")]
        [StringLength(6)]
        public string Level3 { get; set; }

        [InverseProperty("SubdivisionLevel")]
        public virtual ICollection<PlattedLegal> PlattedLegal { get; set; }
    }
}