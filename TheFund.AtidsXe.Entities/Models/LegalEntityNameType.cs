using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("LEGAL_ENTITY_NAME_TYPE")]
    public partial class LegalEntityNameType
    {
        public LegalEntityNameType()
        {
            LegalEntityName = new HashSet<LegalEntityName>();
        }

        [Column("LEGAL_ENTITY_NAME_TYPE_ID")]
        public int LegalEntityNameTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("LegalEntityNameType")]
        public virtual ICollection<LegalEntityName> LegalEntityName { get; set; }
    }
}