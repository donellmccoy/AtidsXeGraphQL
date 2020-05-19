using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WorksheetItem
    {
        [JsonProperty]
        public int TitleEventId { get; set; }
        [JsonProperty]
        public int WorksheetId { get; set; }
        [JsonProperty]
        public int Sequence { get; set; }
    }
}
