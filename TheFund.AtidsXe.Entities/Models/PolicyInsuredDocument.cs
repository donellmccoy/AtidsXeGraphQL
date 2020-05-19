using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY_INSURED_DOCUMENT")]
    public partial class PolicyInsuredDocument
    {
        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Column("GEOGRAPHIC_LOCALE_ID")]
        public int GeographicLocaleId { get; set; }
        [Required]
        [Column("UNPARSED_INSURED_DOCUMENT")]
        [StringLength(24)]
        public string UnparsedInsuredDocument { get; set; }

        [ForeignKey("GeographicLocaleId")]
        [InverseProperty("PolicyInsuredDocument")]
        public virtual GeographicLocale GeographicLocale { get; set; }
        [ForeignKey("PolicyId")]
        [InverseProperty("PolicyInsuredDocument")]
        public virtual Policy Policy { get; set; }
    }
}