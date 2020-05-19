using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PlatReference
    {
        [JsonProperty]
        public int PlatReferenceId { get; set; }
        [JsonProperty]
        public string Source { get; set; }
        [JsonProperty]
        public string Book { get; set; }
        [JsonProperty]
        public string BookSuffix { get; set; }
        [JsonProperty]
        public string Page { get; set; }
        [JsonProperty]
        public string PageSuffix { get; set; }
        [JsonProperty]
        public PlatProperties PlatProperties { get; set; }
    }
}
