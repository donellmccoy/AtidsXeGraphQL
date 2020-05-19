using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("PLAT_PROPERTIES")]
    public partial class PlatProperties
    {
        [Key]
        [Column("PLAT_REFERENCE_ID")]
        public int PlatReferenceId { get; set; }
        [Column("CERTIFICATION_DATE", TypeName = "datetime")]
        public DateTime? CertificationDate { get; set; }
        [Column("PLAT_NAME")]
        [StringLength(184)]
        public string PlatName { get; set; }
        [Column("PLAT_DATE", TypeName = "datetime")]
        public DateTime? PlatDate { get; set; }
        [Column("POSTINGS_CONFORM")]
        public byte? PostingsConform { get; set; }
        [Column("INTERVAL_OWNERSHIP")]
        public byte? IntervalOwnership { get; set; }
        [Column("RETRO_CERTIFIED")]
        public byte? RetroCertified { get; set; }
        [Column("PRIMARY_HIERARCHY")]
        [StringLength(64)]
        public string PrimaryHierarchy { get; set; }
        [Column("ALTERNATE_HIERARCHY_1")]
        [StringLength(64)]
        public string AlternateHierarchy1 { get; set; }
        [Column("ALTERNATE_HIERARCHY_2")]
        [StringLength(64)]
        public string AlternateHierarchy2 { get; set; }

        [ForeignKey("PlatReferenceId")]
        [InverseProperty("PlatProperties")]
        public virtual PlatReference PlatReference { get; set; }
    }
}