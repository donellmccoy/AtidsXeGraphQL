using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SEARCH_STATUS")]
    public partial class SearchStatus
    {
        public SearchStatus()
        {
            Search = new HashSet<Search>();
        }

        [Column("SEARCH_STATUS_ID")]
        public int SearchStatusId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("SearchStatus")]
        public virtual ICollection<Search> Search { get; set; }
    }
}