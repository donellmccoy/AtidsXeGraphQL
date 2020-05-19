using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainOfTitleSearch
    {
        [JsonProperty]
        public int ChainOfTitleId { get; set; }
        [JsonProperty]
        public int SearchId { get; set; }
        [JsonProperty]
        public ChainOfTitle ChainOfTitle { get; set; }
        [JsonProperty]
        public Search Search { get; set; }
    }
}
