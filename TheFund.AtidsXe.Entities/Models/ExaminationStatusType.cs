using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("EXAMINATION_STATUS_TYPE")]
    public partial class ExaminationStatusType
    {
        public ExaminationStatusType()
        {
            TitleEventCurrentExamStatusType = new HashSet<TitleEvent>();
            TitleEventOriginalExamStatusType = new HashSet<TitleEvent>();
        }

        [Column("EXAMINATION_STATUS_TYPE_ID")]
        public int ExaminationStatusTypeId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("CurrentExamStatusType")]
        public virtual ICollection<TitleEvent> TitleEventCurrentExamStatusType { get; set; }
        [InverseProperty("OriginalExamStatusType")]
        public virtual ICollection<TitleEvent> TitleEventOriginalExamStatusType { get; set; }
    }
}