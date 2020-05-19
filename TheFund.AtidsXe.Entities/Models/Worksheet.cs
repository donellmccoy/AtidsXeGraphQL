using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("WORKSHEET")]
    public partial class Worksheet
    {
        public Worksheet()
        {
            PolicyWorksheetItem = new HashSet<PolicyWorksheetItem>();
            WorksheetItem = new HashSet<WorksheetItem>();
        }

        [Column("WORKSHEET_ID")]
        public int WorksheetId { get; set; }
        [Column("FILE_REFERENCE_ID")]
        public int FileReferenceId { get; set; }

        [ForeignKey("FileReferenceId")]
        [InverseProperty("Worksheet")]
        public virtual FileReference FileReference { get; set; }
        [InverseProperty("Worksheet")]
        public virtual ICollection<PolicyWorksheetItem> PolicyWorksheetItem { get; set; }
        [InverseProperty("Worksheet")]
        public virtual ICollection<WorksheetItem> WorksheetItem { get; set; }
    }
}