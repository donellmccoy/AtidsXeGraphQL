using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("USER_PROFILE_FILE_REFERENCE")]
    public partial class UserProfileFileReference
    {
        [Column("PROFILE_ID")]
        public int ProfileId { get; set; }
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Column("FILE_REFERENCE_ID")]
        public int FileReferenceId { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("CREATED_DATE", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column("MODIFIED_BY")]
        public int ModifiedBy { get; set; }
        [Column("MODIFIED_DATE", TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("UserProfileFileReferenceCreatedByNavigation")]
        public virtual User CreatedByNavigation { get; set; }
        [ForeignKey("FileReferenceId")]
        [InverseProperty("UserProfileFileReference")]
        public virtual FileReference FileReference { get; set; }
        [ForeignKey("ModifiedBy")]
        [InverseProperty("UserProfileFileReferenceModifiedByNavigation")]
        public virtual User ModifiedByNavigation { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserProfileFileReferenceUser")]
        public virtual User User { get; set; }
        [ForeignKey("ProfileId,UserId")]
        [InverseProperty("UserProfileFileReference")]
        public virtual UserProfile UserProfile { get; set; }
    }
}