using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("MORTGAGE_TITLE_EVENT")]
    public partial class MortgageTitleEvent
    {
        [Key]
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Required]
        [Column("LENDER_NAME")]
        [StringLength(200)]
        public string LenderName { get; set; }
        [Column("MIN_NUMBER_ID")]
        public int MinNumberId { get; set; }

        [ForeignKey("MinNumberId")]
        [InverseProperty("MortgageTitleEvent")]
        public virtual MinNumber MinNumber { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("MortgageTitleEvent")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}