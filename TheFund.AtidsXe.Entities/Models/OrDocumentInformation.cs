using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("OR_DOCUMENT_INFORMATION")]
    public partial class OrDocumentInformation
    {
        [Key]
        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }
        [Column("DATE_OF_FILING", TypeName = "datetime")]
        public DateTime? DateOfFiling { get; set; }
        [Column("TYPE_OF_INSTRUMENT_ID")]
        public int TypeOfInstrumentId { get; set; }
        [Column("TOI_ADDITIONAL_INFORMATION")]
        [StringLength(50)]
        public string ToiAdditionalInformation { get; set; }
        [Column("UNPARSED_RELATED_REFERENCE")]
        [StringLength(256)]
        public string UnparsedRelatedReference { get; set; }
        [Column("UNPARSED_LEGAL_DESCRIPTION")]
        [StringLength(800)]
        public string UnparsedLegalDescription { get; set; }
        [Column("AMOUNT", TypeName = "numeric(13, 2)")]
        public decimal? Amount { get; set; }
        [Column("PAGE_COUNT")]
        public int? PageCount { get; set; }
        [Column("IMAGE_AVAILABLE")]
        public byte ImageAvailable { get; set; }
        [Column("SCRIVNER_NAME")]
        [StringLength(50)]
        public string ScrivnerName { get; set; }
        [Column("COMMENTS")]
        [StringLength(256)]
        public string Comments { get; set; }
        [Column("CRITICAL_ITEMS_HASH")]
        public int? CriticalItemsHash { get; set; }
        [Column("FULL_HASH")]
        public int? FullHash { get; set; }
        [Column("LAST_IMAGE_UPDATE", TypeName = "datetime")]
        public DateTime? LastImageUpdate { get; set; }
        [Column("MD5_CRITICAL_ITEMS_HASH")]
        [StringLength(50)]
        public string Md5CriticalItemsHash { get; set; }

        [ForeignKey("OfficialRecordDocumentId")]
        [InverseProperty("OrDocumentInformation")]
        public virtual OfficialRecordDocument OfficialRecordDocument { get; set; }
        [ForeignKey("TypeOfInstrumentId")]
        [InverseProperty("OrDocumentInformation")]
        public virtual TypeOfInstrument TypeOfInstrument { get; set; }
    }
}