using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_TYPE_CATEGORY")]
    public partial class TitleEventTypeCategory
    {
        public TitleEventTypeCategory()
        {
            TitleEventType = new HashSet<TitleEventType>();
        }

        [Key]
        [Column("TITLE_EVENT_CATEGORY_ID")]
        public int TitleEventCategoryId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("EventCategory")]
        public virtual ICollection<TitleEventType> TitleEventType { get; set; }
    }
}