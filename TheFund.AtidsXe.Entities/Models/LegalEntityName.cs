using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("LEGAL_ENTITY_NAME")]
    public partial class LegalEntityName
    {
        public LegalEntityName()
        {
            NameSearchListItem = new HashSet<NameSearchListItem>();
            NameSearchParameters = new HashSet<NameSearchParameters>();
            PartyLegalEntityName = new HashSet<PartyLegalEntityName>();
            TitleEventLegalEntityMql = new HashSet<TitleEventLegalEntityMql>();
        }

        [Column("LEGAL_ENTITY_NAME_ID")]
        public int LegalEntityNameId { get; set; }
        [Required]
        [Column("UNPARSED_LEGAL_ENTITY_NAME")]
        [StringLength(256)]
        public string UnparsedLegalEntityName { get; set; }
        [Column("LEGAL_ENTITY_NAME_TYPE_ID")]
        public int LegalEntityNameTypeId { get; set; }
        [Column("COMMENTS")]
        [StringLength(256)]
        public string Comments { get; set; }

        [ForeignKey("LegalEntityNameTypeId")]
        [InverseProperty("LegalEntityName")]
        public virtual LegalEntityNameType LegalEntityNameType { get; set; }
        [InverseProperty("LegalEntityName")]
        public virtual PersonalLegalEntityName PersonalLegalEntityName { get; set; }
        [InverseProperty("LegalEntityName")]
        public virtual ICollection<NameSearchListItem> NameSearchListItem { get; set; }
        [InverseProperty("LegalEntityName")]
        public virtual ICollection<NameSearchParameters> NameSearchParameters { get; set; }
        [InverseProperty("LegalEntityName")]
        public virtual ICollection<PartyLegalEntityName> PartyLegalEntityName { get; set; }
        [InverseProperty("LegalEntityName")]
        public virtual ICollection<TitleEventLegalEntityMql> TitleEventLegalEntityMql { get; set; }
    }
}