using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("DELIVERY_ORDER_INFO")]
    public partial class DeliveryOrderInfo
    {
        public DeliveryOrderInfo()
        {
            PolicyOrderTracking = new HashSet<PolicyOrderTracking>();
            TitleEventOrderTracking = new HashSet<TitleEventOrderTracking>();
        }

        [Column("DELIVERY_ORDER_INFO_ID")]
        public int DeliveryOrderInfoId { get; set; }
        [Column("PAGE_COUNT")]
        public int? PageCount { get; set; }
        [Column("IMAGED_FLAG")]
        public byte ImagedFlag { get; set; }
        [Column("MODIFIED_DATE", TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column("EMAIL")]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty("DeliveryOrderInfo")]
        public virtual ICollection<PolicyOrderTracking> PolicyOrderTracking { get; set; }
        [InverseProperty("DeliveryOrderInfo")]
        public virtual ICollection<TitleEventOrderTracking> TitleEventOrderTracking { get; set; }
    }
}