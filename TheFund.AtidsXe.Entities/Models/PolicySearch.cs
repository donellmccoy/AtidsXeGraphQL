using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_SEARCH")]
    public partial class PolicySearch
    {
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }

        [ForeignKey("PolicyId")]
        [InverseProperty("PolicySearch")]
        public virtual Policy Policy { get; set; }
        [ForeignKey("SearchId")]
        [InverseProperty("PolicySearch")]
        public virtual Search Search { get; set; }
    }
}