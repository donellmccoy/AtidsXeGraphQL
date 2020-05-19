using Newtonsoft.Json;
using System;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TitleSearchOrigination
    {
        [JsonProperty]
        public int TitleSearchOriginationId { get; set; }
        [JsonProperty]
        public DateTime OrderDate { get; set; }
        [JsonProperty]
        public string OrderReference { get; set; }
        [JsonProperty]
        public int TitleEventId { get; set; }
        [JsonProperty]
        public int FileReferenceId { get; set; }
    }
}
