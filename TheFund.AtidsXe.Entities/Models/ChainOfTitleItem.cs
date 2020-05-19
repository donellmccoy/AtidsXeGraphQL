using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("CHAIN_OF_TITLE_ITEM")]
    public partial class ChainOfTitleItem
    {
        [Column("CHAIN_OF_TITLE_ITEM_ID")]
        public int ChainOfTitleItemId { get; set; }
        [Column("CHAIN_OF_TITLE_ID")]
        public int ChainOfTitleId { get; set; }
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("PARENT_TITLE_EVENT_ID")]
        public int? ParentTitleEventId { get; set; }
        [Column("ORDER_INDEX")]
        public int OrderIndex { get; set; }
        [Column("USER_MODIFIED")]
        public byte UserModified { get; set; }
        [Column("STARTING_TITLE_EVENT")]
        public byte StartingTitleEvent { get; set; }
        [Column("CHAIN_OF_TITLE_CATEGORY_ID")]
        public int ChainOfTitleCategoryId { get; set; }

        [ForeignKey("ChainOfTitleId")]
        [InverseProperty("ChainOfTitleItem")]
        public virtual ChainOfTitle ChainOfTitle { get; set; }
        [ForeignKey("ChainOfTitleCategoryId")]
        [InverseProperty("ChainOfTitleItem")]
        public virtual ChainOfTitleCategory ChainOfTitleCategory { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("ChainOfTitleItem")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}