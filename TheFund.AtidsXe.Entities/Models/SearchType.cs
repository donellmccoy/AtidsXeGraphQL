using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SEARCH_TYPE")]
    public partial class SearchType
    {
        public SearchType()
        {
            Search = new HashSet<Search>();
        }

        [Column("SEARCH_TYPE_ID")]
        public int SearchTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(25)]
        public string Description { get; set; }

        [InverseProperty("SearchType")]
        public virtual ICollection<Search> Search { get; set; }
    }
}