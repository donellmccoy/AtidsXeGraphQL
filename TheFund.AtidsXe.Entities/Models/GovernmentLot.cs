using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("GOVERNMENT_LOT")]
    public partial class GovernmentLot
    {
        public GovernmentLot()
        {
            GovernmentLotLegal = new HashSet<GovernmentLotLegal>();
        }

        [Column("GOVERNMENT_LOT_ID")]
        public int GovernmentLotId { get; set; }
        [Required]
        [Column("GOVERNMENT_LOT_NUMBER")]
        [StringLength(10)]
        public string GovernmentLotNumber { get; set; }

        [InverseProperty("GovernmentLot")]
        public virtual ICollection<GovernmentLotLegal> GovernmentLotLegal { get; set; }
    }
}