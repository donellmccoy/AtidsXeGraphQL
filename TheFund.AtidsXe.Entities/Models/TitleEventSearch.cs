using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT_SEARCH")]
    public partial class TitleEventSearch
    {
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }

        [ForeignKey("SearchId")]
        [InverseProperty("TitleEventSearch")]
        public virtual Search Search { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleEventSearch")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}