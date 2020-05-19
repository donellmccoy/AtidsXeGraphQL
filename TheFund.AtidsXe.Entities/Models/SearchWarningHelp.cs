using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SEARCH_WARNING_HELP")]
    public partial class SearchWarningHelp
    {
        [Key]
        [Column("SEARCH_WARNING_TYPE_ID")]
        public int SearchWarningTypeId { get; set; }
        [Required]
        [Column("HELP_TEXT")]
        [StringLength(256)]
        public string HelpText { get; set; }

        [ForeignKey("SearchWarningTypeId")]
        [InverseProperty("SearchWarningHelp")]
        public virtual SearchWarningType SearchWarningType { get; set; }
    }
}