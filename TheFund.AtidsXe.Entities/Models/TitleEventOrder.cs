using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_ORDER")]
    public partial class TitleEventOrder
    {
        public TitleEventOrder()
        {
            TitleEventOrderTracking = new HashSet<TitleEventOrderTracking>();
        }

        [Column("TITLE_EVENT_ORDER_ID")]
        public int TitleEventOrderId { get; set; }
        [Required]
        [Column("TRACKING_IDENTIFIER")]
        [StringLength(60)]
        public string TrackingIdentifier { get; set; }
        [Column("ORDER_DATE", TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [InverseProperty("TitleEventOrder")]
        public virtual ICollection<TitleEventOrderTracking> TitleEventOrderTracking { get; set; }
    }
}