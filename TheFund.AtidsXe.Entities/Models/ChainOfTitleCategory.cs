using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("CHAIN_OF_TITLE_CATEGORY")]
    public partial class ChainOfTitleCategory
    {
        public ChainOfTitleCategory()
        {
            ChainOfTitleItem = new HashSet<ChainOfTitleItem>();
        }

        [Column("CHAIN_OF_TITLE_CATEGORY_ID")]
        public int ChainOfTitleCategoryId { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("ChainOfTitleCategory")]
        public virtual ICollection<ChainOfTitleItem> ChainOfTitleItem { get; set; }
    }
}