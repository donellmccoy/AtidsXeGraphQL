using Newtonsoft.Json;
using System;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChainOfTitleNotes
    {
        [JsonProperty]
        public int ChainOfTitleNotesId { get; set; }
        [JsonProperty]
        public int ChainOfTitleId { get; set; }
        [JsonProperty]
        public string UserId { get; set; }
        [JsonProperty]
        public DateTime TimeStamp { get; set; }
        [JsonProperty]
        public string Message { get; set; }
    }
}
