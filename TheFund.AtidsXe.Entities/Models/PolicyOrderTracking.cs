using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_ORDER_TRACKING")]
    public partial class PolicyOrderTracking
    {
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Column("POLICY_ORDER_ID")]
        public int PolicyOrderId { get; set; }
        [Column("DELIVERY_ORDER_INFO_ID")]
        public int DeliveryOrderInfoId { get; set; }

        [ForeignKey("DeliveryOrderInfoId")]
        [InverseProperty("PolicyOrderTracking")]
        public virtual DeliveryOrderInfo DeliveryOrderInfo { get; set; }
        [ForeignKey("PolicyId")]
        [InverseProperty("PolicyOrderTracking")]
        public virtual Policy Policy { get; set; }
        [ForeignKey("PolicyOrderId")]
        [InverseProperty("PolicyOrderTracking")]
        public virtual PolicyOrder PolicyOrder { get; set; }
    }
}