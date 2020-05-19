using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SEARCH_WARNING")]
    public partial class SearchWarning
    {
        [Column("SEARCH_WARNING_ID")]
        public int SearchWarningId { get; set; }
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
        [Column("SEARCH_WARNING_TYPE_ID")]
        public int SearchWarningTypeId { get; set; }
        [Required]
        [Column("UNPARSED_SEARCH_WARNING")]
        [StringLength(1024)]
        public string UnparsedSearchWarning { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [ForeignKey("SearchId")]
        [InverseProperty("SearchWarning")]
        public virtual Search Search { get; set; }
        [ForeignKey("SearchWarningTypeId")]
        [InverseProperty("SearchWarning")]
        public virtual SearchWarningType SearchWarningType { get; set; }
    }
}