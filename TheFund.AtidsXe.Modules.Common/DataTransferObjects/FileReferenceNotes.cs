using Newtonsoft.Json;
using System;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FileReferenceNotes
    {
        [JsonProperty]
        public int FileReferenceNotesId { get; set; }
        [JsonProperty]
        public int FileReferenceId { get; set; }
        [JsonProperty]
        public string UserId { get; set; }
        [JsonProperty]
        public DateTime TimeStamp { get; set; }
        [JsonProperty]
        public string Message { get; set; }
    }
}
