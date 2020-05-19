using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("NAME_SEARCH_LIST_ITEM ")]
    public partial class NameSearchListItem
    {
        public NameSearchListItem()
        {
            NameSearchListReasonCode = new HashSet<NameSearchListReasonCode>();
        }

        [Column("NAME_SEARCH_LIST_ITEM_ID")]
        public int NameSearchListItemId { get; set; }
        [Column("LEGAL_ENTITY_NAME_ID")]
        public int LegalEntityNameId { get; set; }
        [Column("CHAIN_OF_TITLE_ID")]
        public int ChainOfTitleId { get; set; }
        [Column("NAME_SEARCH_STATUS_CODE_ID")]
        public int NameSearchStatusCodeId { get; set; }
        [Column("REFERENCE_TITLE_EVENT_ID")]
        public int ReferenceTitleEventId { get; set; }

        [ForeignKey("LegalEntityNameId")]
        [InverseProperty("NameSearchListItem")]
        public virtual LegalEntityName LegalEntityName { get; set; }
        [ForeignKey("NameSearchStatusCodeId")]
        [InverseProperty("NameSearchListItem")]
        public virtual NameSearchStatusCode NameSearchStatusCode { get; set; }
        [ForeignKey("ReferenceTitleEventId")]
        [InverseProperty("NameSearchListItem")]
        public virtual TitleEvent ReferenceTitleEvent { get; set; }
        [InverseProperty("NameSearchListItem")]
        public virtual ICollection<NameSearchListReasonCode> NameSearchListReasonCode { get; set; }
    }
}