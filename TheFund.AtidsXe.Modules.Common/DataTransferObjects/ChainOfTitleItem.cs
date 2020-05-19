using Newtonsoft.Json;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainOfTitleItem
    {
        [JsonProperty]
        public int ChainOfTitleItemId { get; set; }
        [JsonProperty]
        public int ChainOfTitleId { get; set; }
        [JsonProperty]
        public int TitleEventId { get; set; }
        [JsonProperty]
        public int? ParentTitleEventId { get; set; }
        [JsonProperty]
        public int OrderIndex { get; set; }
        [JsonProperty]
        public byte UserModified { get; set; }
        [JsonProperty]
        public byte StartingTitleEvent { get; set; }
        [JsonProperty]
        public int ChainOfTitleCategoryId { get; set; }
        [JsonProperty]
        public ChainOfTitle ChainOfTitle { get; set; }
        [JsonProperty]
        public ChainOfTitleCategory ChainOfTitleCategory { get; set; }
    }
}
