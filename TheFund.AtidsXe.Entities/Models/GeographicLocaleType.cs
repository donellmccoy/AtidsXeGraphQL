using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("GEOGRAPHIC_LOCALE_TYPE")]
    public partial class GeographicLocaleType
    {
        public GeographicLocaleType()
        {
            GeographicLocale = new HashSet<GeographicLocale>();
        }

        [Column("GEOGRAPHIC_LOCALE_TYPE_ID")]
        public int GeographicLocaleTypeId { get; set; }
        [Required]
        [Column("TYPE_NAME")]
        [StringLength(50)]
        public string TypeName { get; set; }

        [InverseProperty("GeographicLocaleType")]
        public virtual ICollection<GeographicLocale> GeographicLocale { get; set; }
    }
}