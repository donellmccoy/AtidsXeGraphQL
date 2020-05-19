using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("FILE_STATUS")]
    public partial class FileStatus
    {
        public FileStatus()
        {
            FileReference = new HashSet<FileReference>();
        }

        [Column("FILE_STATUS_ID")]
        public int FileStatusId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(15)]
        public string Description { get; set; }

        [InverseProperty("FileStatus")]
        public virtual ICollection<FileReference> FileReference { get; set; }
    }
}