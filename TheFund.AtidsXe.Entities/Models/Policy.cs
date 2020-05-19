using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("POLICY")]
    public partial class Policy
    {
        public Policy()
        {
            PolicyGovtLotLegalMql = new HashSet<PolicyGovtLotLegalMql>();
            PolicyInsuredDocument = new HashSet<PolicyInsuredDocument>();
            PolicyNotes = new HashSet<PolicyNotes>();
            PolicyOrderTracking = new HashSet<PolicyOrderTracking>();
            PolicyPlattedLegalMql = new HashSet<PolicyPlattedLegalMql>();
            PolicySearch = new HashSet<PolicySearch>();
            PolicySectionLegalMql = new HashSet<PolicySectionLegalMql>();
            PolicyWorksheetItem = new HashSet<PolicyWorksheetItem>();
        }

        [Column("POLICY_ID")]
        public int PolicyId { get; set; }
        [Required]
        [Column("POLICY_TYPE")]
        [StringLength(5)]
        public string PolicyType { get; set; }
        [Column("POLICY_NUMBER")]
        public int PolicyNumber { get; set; }
        [Column("POLICY_RESTRICTION_TYPE_ID")]
        public int PolicyRestrictionTypeId { get; set; }
        [Column("EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime EffectiveDate { get; set; }
        [Required]
        [Column("MEMBER_NUMBER")]
        [StringLength(7)]
        public string MemberNumber { get; set; }
        [Column("INSURED_AMOUNT", TypeName = "numeric(11, 2)")]
        public decimal? InsuredAmount { get; set; }
        [Column("IMAGE_AVAILABLE")]
        public byte? ImageAvailable { get; set; }
        [Column("TITLE_BASE_INDICATOR")]
        public byte? TitleBaseIndicator { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column("SYSTEM_UPDATE_DATE", TypeName = "datetime")]
        public DateTime? SystemUpdateDate { get; set; }
        [Column("USER_UPDATE_DATE", TypeName = "datetime")]
        public DateTime? UserUpdateDate { get; set; }

        [ForeignKey("PolicyRestrictionTypeId")]
        [InverseProperty("Policy")]
        public virtual PolicyRestrictionType PolicyRestrictionType { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicyGovtLotLegalMql> PolicyGovtLotLegalMql { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicyInsuredDocument> PolicyInsuredDocument { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicyNotes> PolicyNotes { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicyOrderTracking> PolicyOrderTracking { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicyPlattedLegalMql> PolicyPlattedLegalMql { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicySearch> PolicySearch { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicySectionLegalMql> PolicySectionLegalMql { get; set; }
        [InverseProperty("Policy")]
        public virtual ICollection<PolicyWorksheetItem> PolicyWorksheetItem { get; set; }
    }
}