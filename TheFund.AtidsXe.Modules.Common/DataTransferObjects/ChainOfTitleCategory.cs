using Newtonsoft.Json;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainOfTitleCategory
    {
        [JsonProperty]
        public int ChainOfTitleCategoryId { get; set; }
        [JsonProperty]
        public string Description { get; set; }
    }
}
