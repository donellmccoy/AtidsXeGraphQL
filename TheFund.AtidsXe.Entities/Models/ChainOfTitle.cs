using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("CHAIN_OF_TITLE")]
    public partial class ChainOfTitle
    {
        public ChainOfTitle()
        {
            ChainOfTitleItem = new HashSet<ChainOfTitleItem>();
            ChainOfTitleNotes = new HashSet<ChainOfTitleNotes>();
            ChainOfTitleSearch = new HashSet<ChainOfTitleSearch>();
        }

        [Column("CHAIN_OF_TITLE_ID")]
        public int ChainOfTitleId { get; set; }
        [Column("FILE_REFERENCE_ID")]
        public int FileReferenceId { get; set; }

        [ForeignKey("FileReferenceId")]
        [InverseProperty("ChainOfTitle")]
        public virtual FileReference FileReference { get; set; }
        [InverseProperty("ChainOfTitle")]
        public virtual ICollection<ChainOfTitleItem> ChainOfTitleItem { get; set; }
        [InverseProperty("ChainOfTitle")]
        public virtual ICollection<ChainOfTitleNotes> ChainOfTitleNotes { get; set; }
        [InverseProperty("ChainOfTitle")]
        public virtual ICollection<ChainOfTitleSearch> ChainOfTitleSearch { get; set; }
    }
}