using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("NAME_SEARCH_LIST_REASON_CODE")]
    public partial class NameSearchListReasonCode
    {
        [Column("NAME_SEARCH_LIST_ITEM_ID")]
        public int NameSearchListItemId { get; set; }
        [Column("NAME_REASON_CODE_ID")]
        public int NameReasonCodeId { get; set; }

        [ForeignKey("NameReasonCodeId")]
        [InverseProperty("NameSearchListReasonCode")]
        public virtual NameReasonCode NameReasonCode { get; set; }
        [ForeignKey("NameSearchListItemId")]
        [InverseProperty("NameSearchListReasonCode")]
        public virtual NameSearchListItem NameSearchListItem { get; set; }
    }
}