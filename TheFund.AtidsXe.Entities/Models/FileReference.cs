using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("FILE_REFERENCE")]
    public partial class FileReference
    {
        public FileReference()
        {
            ChainOfTitle = new HashSet<ChainOfTitle>();
            FileReferenceNotes = new HashSet<FileReferenceNotes>();
            Search = new HashSet<Search>();
            UserProfileFileReference = new HashSet<UserProfileFileReference>();
        }

        [Column("FILE_REFERENCE_ID")]
        public int FileReferenceId { get; set; }
        [Column("BRANCH_LOCATION_ID")]
        public int BranchLocationId { get; set; }
        [Required]
        [Column("FILE_REFERENCE")]
        [StringLength(50)]
        public string FileReference1 { get; set; }
        [Column("FILE_STATUS_ID")]
        public int FileStatusId { get; set; }
        [Column("WORKER_ID")]
        [StringLength(30)]
        public string WorkerId { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column("UPDATE_DATE", TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }
        [Column("DEFAULT_GEOGRAPHIC_LOCALE_ID")]
        public int? DefaultGeographicLocaleId { get; set; }
        [Column("IS_TEMPORARY_FILE")]
        public byte? IsTemporaryFile { get; set; }

        [ForeignKey("BranchLocationId")]
        [InverseProperty("FileReference")]
        public virtual BranchLocation BranchLocation { get; set; }
        [ForeignKey("DefaultGeographicLocaleId")]
        [InverseProperty("FileReference")]
        public virtual GeographicLocale DefaultGeographicLocale { get; set; }
        [ForeignKey("FileStatusId")]
        [InverseProperty("FileReference")]
        public virtual FileStatus FileStatus { get; set; }
        [InverseProperty("FileReference")]
        public virtual TitleSearchOrigination TitleSearchOrigination { get; set; }
        [InverseProperty("FileReference")]
        public virtual Worksheet Worksheet { get; set; }
        [InverseProperty("FileReference")]
        public virtual ICollection<ChainOfTitle> ChainOfTitle { get; set; }
        [InverseProperty("FileReference")]
        public virtual ICollection<FileReferenceNotes> FileReferenceNotes { get; set; }
        [InverseProperty("FileReference")]
        public virtual ICollection<Search> Search { get; set; }
        [InverseProperty("FileReference")]
        public virtual ICollection<UserProfileFileReference> UserProfileFileReference { get; set; }
    }
}