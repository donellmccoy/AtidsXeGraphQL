using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_STATUS_ASSIGNOR")]
    public partial class TitleEventStatusAssignor
    {
        public TitleEventStatusAssignor()
        {
            TitleEvent = new HashSet<TitleEvent>();
        }

        [Column("TITLE_EVENT_STATUS_ASSIGNOR_ID")]
        public int TitleEventStatusAssignorId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(32)]
        public string Description { get; set; }

        [InverseProperty("TitleEventStatusAssignor")]
        public virtual ICollection<TitleEvent> TitleEvent { get; set; }
    }
}