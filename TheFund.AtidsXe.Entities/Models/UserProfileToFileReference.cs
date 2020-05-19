using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("USER_PROFILE_TO_FILE_REFERENCE")]
    public partial class UserProfileToFileReference
    {
        [Key]
        [Column("USER_PROFILE_FILE_REFERENCE_ID")]
        public int UserProfileFileReferenceId { get; set; }
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Column("PROFILE_ID")]
        public int ProfileId { get; set; }
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

        [ForeignKey("FileReferenceId")]
        [InverseProperty("UserProfileToFileReference")]
        public virtual FileReference FileReference { get; set; }
        [ForeignKey("ProfileId")]
        [InverseProperty("UserProfileToFileReference")]
        public virtual UserProfile Profile { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserProfileToFileReference")]
        public virtual User User { get; set; }
    }
}