using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("CASE_NUMBER_REFERENCE")]
    public partial class CaseNumberReference
    {
        public CaseNumberReference()
        {
            RelatedCaseNumber = new HashSet<RelatedCaseNumber>();
        }

        [Column("CASE_NUMBER_REFERENCE_ID")]
        public int CaseNumberReferenceId { get; set; }
        [Required]
        [Column("SOURCE")]
        [StringLength(2)]
        public string Source { get; set; }
        [Column("RECORDING_YEAR")]
        public int RecordingYear { get; set; }
        [Column("RECORDING_NUMBER")]
        public int RecordingNumber { get; set; }
        [Column("SUFFIX")]
        [StringLength(1)]
        public string Suffix { get; set; }
        [Column("SERIES_CODE")]
        [StringLength(1)]
        public string SeriesCode { get; set; }
        [Column("GEOGRAPHIC_LOCALE_ID")]
        public int? GeographicLocaleId { get; set; }

        [ForeignKey("GeographicLocaleId")]
        [InverseProperty("CaseNumberReference")]
        public virtual GeographicLocale GeographicLocale { get; set; }
        [InverseProperty("CaseNumberReference")]
        public virtual ICollection<RelatedCaseNumber> RelatedCaseNumber { get; set; }
    }
}