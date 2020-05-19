using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TYPE_OF_INSTRUMENT")]
    public partial class TypeOfInstrument
    {
        public TypeOfInstrument()
        {
            OrDocumentInformation = new HashSet<OrDocumentInformation>();
        }

        [Column("TYPE_OF_INSTRUMENT_ID")]
        public int TypeOfInstrumentId { get; set; }
        [Required]
        [Column("TYPE_OF_INSTRUMENT")]
        [StringLength(3)]
        public string TypeOfInstrument1 { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("TypeOfInstrument")]
        public virtual ICollection<OrDocumentInformation> OrDocumentInformation { get; set; }
    }
}