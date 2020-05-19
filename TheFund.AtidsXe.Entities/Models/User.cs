using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("USER")]
    public partial class User
    {
        public User()
        {
            InverseCreatedByNavigation = new HashSet<User>();
            InverseModifiedByNavigation = new HashSet<User>();
            UserProfileCreatedByNavigation = new HashSet<UserProfile>();
            UserProfileFileReferenceCreatedByNavigation = new HashSet<UserProfileFileReference>();
            UserProfileFileReferenceModifiedByNavigation = new HashSet<UserProfileFileReference>();
            UserProfileFileReferenceUser = new HashSet<UserProfileFileReference>();
            UserProfileModifiedByNavigation = new HashSet<UserProfile>();
            UserProfileUser = new HashSet<UserProfile>();
        }

        [Column("USER_ID")]
        public int UserId { get; set; }
        [Required]
        [Column("FIRST_NAME")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("MIDDLE_NAME")]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [Column("LAST_NAME")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("USER_NAME")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("CREATED_DATE", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("MODIFIED_BY")]
        public int ModifiedBy { get; set; }
        [Column("MODIFIED_DATE", TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("InverseCreatedByNavigation")]
        public virtual User CreatedByNavigation { get; set; }
        [ForeignKey("ModifiedBy")]
        [InverseProperty("InverseModifiedByNavigation")]
        public virtual User ModifiedByNavigation { get; set; }
        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<User> InverseCreatedByNavigation { get; set; }
        [InverseProperty("ModifiedByNavigation")]
        public virtual ICollection<User> InverseModifiedByNavigation { get; set; }
        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<UserProfile> UserProfileCreatedByNavigation { get; set; }
        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<UserProfileFileReference> UserProfileFileReferenceCreatedByNavigation { get; set; }
        [InverseProperty("ModifiedByNavigation")]
        public virtual ICollection<UserProfileFileReference> UserProfileFileReferenceModifiedByNavigation { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserProfileFileReference> UserProfileFileReferenceUser { get; set; }
        [InverseProperty("ModifiedByNavigation")]
        public virtual ICollection<UserProfile> UserProfileModifiedByNavigation { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserProfile> UserProfileUser { get; set; }
    }
}