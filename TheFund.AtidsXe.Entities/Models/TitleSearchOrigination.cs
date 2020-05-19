using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_SEARCH_ORIGINATION")]
    public partial class TitleSearchOrigination
    {
        [Column("TITLE_SEARCH_ORIGINATION_ID")]
        public int TitleSearchOriginationId { get; set; }
        [Column("ORDER_DATE", TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column("ORDER_REFERENCE")]
        [StringLength(50)]
        public string OrderReference { get; set; }
        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("FILE_REFERENCE_ID")]
        public int FileReferenceId { get; set; }

        [ForeignKey("FileReferenceId")]
        [InverseProperty("TitleSearchOrigination")]
        public virtual FileReference FileReference { get; set; }
        [ForeignKey("TitleEventId")]
        [InverseProperty("TitleSearchOrigination")]
        public virtual TitleEvent TitleEvent { get; set; }
    }
}