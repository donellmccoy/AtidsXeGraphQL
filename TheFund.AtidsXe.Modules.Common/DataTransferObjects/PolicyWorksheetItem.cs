using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PolicyWorksheetItem
    {
        [JsonProperty]
        public int PolicyId { get; set; }
        [JsonProperty]
        public int WorksheetId { get; set; }
        [JsonProperty]
        public int Sequence { get; set; }
    }
}
