using Newtonsoft.Json;
using System;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PlatProperties
    {
        [JsonProperty]
        public int PlatReferenceId { get; set; }
        [JsonProperty]
        public DateTime? CertificationDate { get; set; }
        [JsonProperty]
        public string PlatName { get; set; }
        [JsonProperty]
        public DateTime? PlatDate { get; set; }
        [JsonProperty]
        public byte? PostingsConform { get; set; }
        [JsonProperty]
        public byte? IntervalOwnership { get; set; }
        [JsonProperty]
        public byte? RetroCertified { get; set; }
        [JsonProperty]
        public string PrimaryHierarchy { get; set; }
        [JsonProperty]
        public string AlternateHierarchy1 { get; set; }
        [JsonProperty]
        public string AlternateHierarchy2 { get; set; }
    }
}
