using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("NAME_REASON_CODE")]
    public partial class NameReasonCode
    {
        public NameReasonCode()
        {
            NameSearchListReasonCode = new HashSet<NameSearchListReasonCode>();
        }

        [Column("NAME_REASON_CODE_ID")]
        public int NameReasonCodeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("NameReasonCode")]
        public virtual ICollection<NameSearchListReasonCode> NameSearchListReasonCode { get; set; }
    }
}