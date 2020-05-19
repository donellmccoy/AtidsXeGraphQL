using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PROPERTY_ADDRESS")]
    public partial class PropertyAddress
    {
        [Key]
        [Column("OFFICIAL_RECORD_DOCUMENT_ID")]
        public int OfficialRecordDocumentId { get; set; }
        [Required]
        [Column("ADDRESS_LINE_1")]
        [StringLength(50)]
        public string AddressLine1 { get; set; }
        [Column("ADDRESS_LINE_2")]
        [StringLength(50)]
        public string AddressLine2 { get; set; }
        [Required]
        [Column("CITY")]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [Column("STATE")]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [Column("POSTAL_CODE")]
        [StringLength(50)]
        public string PostalCode { get; set; }
        [Required]
        [Column("COUNTRY")]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [Column("UNPARSED_ADDRESS")]
        [StringLength(310)]
        public string UnparsedAddress { get; set; }

        [ForeignKey("OfficialRecordDocumentId")]
        [InverseProperty("PropertyAddress")]
        public virtual OfficialRecordDocument OfficialRecordDocument { get; set; }
    }
}