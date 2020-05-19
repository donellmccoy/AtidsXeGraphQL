using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("CHAIN_OF_TITLE_SEARCH")]
    public partial class ChainOfTitleSearch
    {
        [Column("CHAIN_OF_TITLE_ID")]
        public int ChainOfTitleId { get; set; }
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }

        [ForeignKey("ChainOfTitleId")]
        [InverseProperty("ChainOfTitleSearch")]
        public virtual ChainOfTitle ChainOfTitle { get; set; }
        [ForeignKey("SearchId")]
        [InverseProperty("ChainOfTitleSearch")]
        public virtual Search Search { get; set; }
    }
}