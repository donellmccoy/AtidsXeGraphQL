using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("YEAR_NUMBER_REFERENCE")]
    public partial class YearNumberReference
    {
        [Key]
        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }
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

        [ForeignKey("OfficialRecordDocumentId")]
        [InverseProperty("YearNumberReference")]
        public virtual OfficialRecordDocument OfficialRecordDocument { get; set; }
    }
}