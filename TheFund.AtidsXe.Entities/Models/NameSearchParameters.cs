using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("NAME_SEARCH_PARAMETERS")]
    public partial class NameSearchParameters
    {
        [Key]
        [Column("SEARCH_ID")]
        public int SearchId { get; set; }
        [Column("LEGAL_ENTITY_NAME_ID")]
        public int LegalEntityNameId { get; set; }
        [Column("SEARCH_GI_NAMES")]
        public byte SearchGiNames { get; set; }
        [Column("SEARCH_GRANTOR_NAMES")]
        public byte SearchGrantorNames { get; set; }
        [Column("SEARCH_GRANTEE_NAMES")]
        public byte SearchGranteeNames { get; set; }
        [Column("SEARCH_NICK_NAMES")]
        public byte SearchNickNames { get; set; }
        [Column("SEARCH_SIMILAR_SOUNDING_NAMES")]
        public byte SearchSimilarSoundingNames { get; set; }
        [Column("FLIP_NAMES")]
        public byte FlipNames { get; set; }
        [Column("LAST_NAME_PCT_OF_LIKENESS")]
        public byte LastNamePctOfLikeness { get; set; }
        [Column("FIRST_NAME_PCT_OF_LIKENESS")]
        public byte FirstNamePctOfLikeness { get; set; }
        [Column("OWNER_BUYER_RELATIONSHIP_ID")]
        public int OwnerBuyerRelationshipId { get; set; }
        [Column("LEGAL_FILTER")]
        [StringLength(10)]
        public string LegalFilter { get; set; }

        [ForeignKey("LegalEntityNameId")]
        [InverseProperty("NameSearchParameters")]
        public virtual LegalEntityName LegalEntityName { get; set; }
        [ForeignKey("OwnerBuyerRelationshipId")]
        [InverseProperty("NameSearchParameters")]
        public virtual OwnerBuyerRelationship OwnerBuyerRelationship { get; set; }
        [ForeignKey("SearchId")]
        [InverseProperty("NameSearchParameters")]
        public virtual Search Search { get; set; }
    }
}