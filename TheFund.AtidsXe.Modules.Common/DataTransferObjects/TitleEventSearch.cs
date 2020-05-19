using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TitleEventSearch
    {
        [JsonProperty]
        public int TitleEventId { get; set; }
        [JsonProperty]
        public TitleEvent TitleEvent { get; set; }
    }
}
