using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("USER_PROFILE")]
    public partial class UserProfile
    {
        public UserProfile()
        {
            UserProfileFileReference = new HashSet<UserProfileFileReference>();
        }

        [Column("PROFILE_ID")]
        public int ProfileId { get; set; }
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(250)]
        public string Description { get; set; }
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }
        [Column("CREATED_DATE", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column("MODIFIED_BY")]
        public int ModifiedBy { get; set; }
        [Column("MODIFIED_DATE", TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("UserProfileCreatedByNavigation")]
        public virtual User CreatedByNavigation { get; set; }
        [ForeignKey("ModifiedBy")]
        [InverseProperty("UserProfileModifiedByNavigation")]
        public virtual User ModifiedByNavigation { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("UserProfileUser")]
        public virtual User User { get; set; }
        [InverseProperty("UserProfile")]
        public virtual ICollection<UserProfileFileReference> UserProfileFileReference { get; set; }
    }
}