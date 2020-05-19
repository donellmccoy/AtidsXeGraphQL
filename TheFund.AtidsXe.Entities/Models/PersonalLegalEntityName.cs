using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PERSONAL_LEGAL_ENTITY_NAME")]
    public partial class PersonalLegalEntityName
    {
        [Key]
        [Column("LEGAL_ENTITY_NAME_ID")]
        public int LegalEntityNameId { get; set; }
        [Required]
        [Column("LAST_NAME")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column("FIRST_NAME")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("MIDDLE_NAME")]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Column("LINEAGE")]
        [StringLength(10)]
        public string Lineage { get; set; }
        [Column("PREFIX")]
        [StringLength(10)]
        public string Prefix { get; set; }
        [Column("SUFFIX")]
        [StringLength(10)]
        public string Suffix { get; set; }

        [ForeignKey("LegalEntityNameId")]
        [InverseProperty("PersonalLegalEntityName")]
        public virtual LegalEntityName LegalEntityName { get; set; }
    }
}