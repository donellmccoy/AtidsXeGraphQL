using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("MIN_NUMBER")]
    public partial class MinNumber
    {
        public MinNumber()
        {
            MortgageTitleEvent = new HashSet<MortgageTitleEvent>();
        }

        [Column("MIN_NUMBER_ID")]
        public int MinNumberId { get; set; }
        [Required]
        [Column("MIN_LENDER")]
        [StringLength(7)]
        public string MinLender { get; set; }
        [Required]
        [Column("MIN_SERIAL")]
        [StringLength(10)]
        public string MinSerial { get; set; }
        [Required]
        [Column("MIN_CHECK_DIGIT")]
        [StringLength(1)]
        public string MinCheckDigit { get; set; }

        [InverseProperty("MinNumber")]
        public virtual ICollection<MortgageTitleEvent> MortgageTitleEvent { get; set; }
    }
}