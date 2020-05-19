using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_ORDER_TRACKING")]
    public partial class TitleEventOrderTracking
    {
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("TITLE_EVENT_ORDER_ID")]
        public int TitleEventOrderId { get; set; }
        [Column("DELIVERY_ORDER_INFO_ID")]
        public int DeliveryOrderInfoId { get; set; }

        [ForeignKey("DeliveryOrderInfoId")]
        [InverseProperty("TitleEventOrderTracking")]
        public virtual DeliveryOrderInfo DeliveryOrderInfo { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventOrderTracking")]
        public virtual TitleEvent TitleEvent { get; set; }
        [ForeignKey("TitleEventOrderId")]
        [InverseProperty("TitleEventOrderTracking")]
        public virtual TitleEventOrder TitleEventOrder { get; set; }
    }
}