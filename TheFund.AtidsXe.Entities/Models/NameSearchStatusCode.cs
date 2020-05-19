using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("NAME_SEARCH_STATUS_CODE")]
    public partial class NameSearchStatusCode
    {
        public NameSearchStatusCode()
        {
            NameSearchListItem = new HashSet<NameSearchListItem>();
        }

        [Column("NAME_SEARCH_STATUS_CODE_ID")]
        public int NameSearchStatusCodeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("NameSearchStatusCode")]
        public virtual ICollection<NameSearchListItem> NameSearchListItem { get; set; }
    }
}