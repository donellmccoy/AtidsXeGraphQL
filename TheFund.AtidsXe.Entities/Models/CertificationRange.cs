using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("CERTIFICATION_RANGE")]
    public partial class CertificationRange
    {
        public CertificationRange()
        {
            SearchGeographicCertRange = new HashSet<Search>();
            SearchGiCertRange = new HashSet<Search>();
            SearchGrantorCertRange = new HashSet<Search>();
        }

        [Column("CERTIFICATION_RANGE_ID")]
        public int CertificationRangeId { get; set; }
        [Column("FROM_DATE", TypeName = "datetime")]
        public DateTime FromDate { get; set; }
        [Column("FROM_OR_DOCUMENT_ID")]
        public int FromOrDocumentId { get; set; }
        [Column("TO_DATE", TypeName = "datetime")]
        public DateTime ToDate { get; set; }
        [Column("TO_OR_DOCUMENT_ID")]
        public int ToOrDocumentId { get; set; }

        [ForeignKey("FromOrDocumentId")]
        [InverseProperty("CertificationRangeFromOrDocument")]
        public virtual OfficialRecordDocument FromOrDocument { get; set; }
        [ForeignKey("ToOrDocumentId")]
        [InverseProperty("CertificationRangeToOrDocument")]
        public virtual OfficialRecordDocument ToOrDocument { get; set; }
        [InverseProperty("GeographicCertRange")]
        public virtual ICollection<Search> SearchGeographicCertRange { get; set; }
        [InverseProperty("GiCertRange")]
        public virtual ICollection<Search> SearchGiCertRange { get; set; }
        [InverseProperty("GrantorCertRange")]
        public virtual ICollection<Search> SearchGrantorCertRange { get; set; }
    }
}