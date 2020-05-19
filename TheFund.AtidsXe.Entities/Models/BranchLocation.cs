using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("BRANCH_LOCATION")]
    public partial class BranchLocation
    {
        public BranchLocation()
        {
            FileReference = new HashSet<FileReference>();
        }

        [Column("BRANCH_LOCATION_ID")]
        public int BranchLocationId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [Column("ACCOUNT_NUMBER")]
        [StringLength(5)]
        public string AccountNumber { get; set; }
        [Column("IS_INTERNAL")]
        public byte? IsInternal { get; set; }

        [InverseProperty("BranchLocation")]
        public virtual ICollection<FileReference> FileReference { get; set; }
    }
}