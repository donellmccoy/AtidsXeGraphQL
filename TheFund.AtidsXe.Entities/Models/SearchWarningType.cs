using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SEARCH_WARNING_TYPE")]
    public partial class SearchWarningType
    {
        public SearchWarningType()
        {
            SearchWarning = new HashSet<SearchWarning>();
        }

        [Column("SEARCH_WARNING_TYPE_ID")]
        public int SearchWarningTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(25)]
        public string Description { get; set; }

        [InverseProperty("SearchWarningType")]
        public virtual SearchWarningHelp SearchWarningHelp { get; set; }
        [InverseProperty("SearchWarningType")]
        public virtual ICollection<SearchWarning> SearchWarning { get; set; }
    }
}