using Newtonsoft.Json;
using System;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TitleEvent
    {
        [JsonProperty]
        public int TitleEventId { get; set; }
        [JsonProperty]
        public int CurrentExamStatusTypeId { get; set; }
        [JsonProperty]
        public int OriginalExamStatusTypeId { get; set; }
        [JsonProperty]
        public int TitleEventStatusAssignorId { get; set; }
        [JsonProperty]
        public int TitleEventTypeId { get; set; }
        [JsonProperty]
        public decimal? Amount { get; set; }
        [JsonProperty]
        public string AdditionalInformation { get; set; }
        [JsonProperty]
        public DateTime? TitleEventDate { get; set; }
        [JsonProperty]
        public DateTime? CreateDate { get; set; }
        [JsonProperty]
        public string Tag { get; set; }
    }
}
