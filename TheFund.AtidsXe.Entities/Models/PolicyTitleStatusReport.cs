using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_TITLE_STATUS_REPORT")]
    public partial class PolicyTitleStatusReport
    {
        [Key]
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
        [Required]
        [Column("TITLE_STATUS_REPORT_CODE")]
        [StringLength(4)]
        public string TitleStatusReportCode { get; set; }
        [Column("TITLE_STATUS_REPORT_NUMBER")]
        [StringLength(20)]
        public string TitleStatusReportNumber { get; set; }

        [ForeignKey("SearchId")]
        [InverseProperty("PolicyTitleStatusReport")]
        public virtual Search Search { get; set; }
    }
}