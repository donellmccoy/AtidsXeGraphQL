using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("SECTION_BREAKDOWN_CODE")]
    public partial class SectionBreakdownCode
    {
        public SectionBreakdownCode()
        {
            SectionLegal = new HashSet<SectionLegal>();
        }

        [Column("SECTION_BREAKDOWN_CODE_ID")]
        public int SectionBreakdownCodeId { get; set; }
        [Column("SECTION_QUARTER")]
        public int SectionQuarter { get; set; }
        [Column("SECTION_16TH")]
        public int? Section16th { get; set; }
        [Column("SECTION_64TH")]
        public int? Section64th { get; set; }
        [Column("SECTION_256TH")]
        public int? Section256th { get; set; }

        [InverseProperty("SectionBreakdownCode")]
        public virtual ICollection<SectionLegal> SectionLegal { get; set; }
    }
}