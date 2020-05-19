using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_TYPE")]
    public partial class TitleEventType
    {
        public TitleEventType()
        {
            TitleEvent = new HashSet<TitleEvent>();
        }

        [Column("TITLE_EVENT_TYPE_ID")]
        public int TitleEventTypeId { get; set; }
        [Required]
        [Column("TITLE_EVENT_CODE")]
        [StringLength(3)]
        public string TitleEventCode { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }
        [Column("EVENT_CATEGORY_ID")]
        public int EventCategoryId { get; set; }

        [ForeignKey("EventCategoryId")]
        [InverseProperty("TitleEventType")]
        public virtual TitleEventTypeCategory EventCategory { get; set; }
        [InverseProperty("TitleEventType")]
        public virtual ICollection<TitleEvent> TitleEvent { get; set; }
    }
}