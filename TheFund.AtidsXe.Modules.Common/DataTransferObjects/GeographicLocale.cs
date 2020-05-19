using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    /// <summary>
    /// Class GeographicLocale.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GeographicLocale
    {
        /// <summary>
        /// Gets or sets the geographic locale identifier.
        /// </summary>
        /// <value>The geographic locale identifier.</value>
        [JsonProperty]
        public int GeographicLocaleId { get; set; }
        /// <summary>
        /// Gets or sets the name of the locale.
        /// </summary>
        /// <value>The name of the locale.</value>
        [JsonProperty]
        public string LocaleName { get; set; }
        /// <summary>
        /// Gets or sets the locale abbreviation.
        /// </summary>
        /// <value>The locale abbreviation.</value>
        [JsonProperty]
        public string LocaleAbbreviation { get; set; }
        /// <summary>
        /// Gets or sets the geographic locale type identifier.
        /// </summary>
        /// <value>The geographic locale type identifier.</value>
        [JsonProperty]
        public int GeographicLocaleTypeId { get; set; }
        /// <summary>
        /// Gets or sets the parent geographic locale identifier.
        /// </summary>
        /// <value>The parent geographic locale identifier.</value>
        [JsonProperty]
        public int? ParentGeographicLocaleId { get; set; }
    }
}
