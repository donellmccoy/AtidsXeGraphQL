using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_ORDER")]
    public partial class PolicyOrder
    {
        public PolicyOrder()
        {
            PolicyOrderTracking = new HashSet<PolicyOrderTracking>();
        }

        [Column("POLICY_ORDER_ID")]
        public int PolicyOrderId { get; set; }
        [Required]
        [Column("TRACKING_IDENTIFIER")]
        [StringLength(60)]
        public string TrackingIdentifier { get; set; }
        [Column("ORDER_DATE", TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [InverseProperty("PolicyOrder")]
        public virtual ICollection<PolicyOrderTracking> PolicyOrderTracking { get; set; }
    }
}