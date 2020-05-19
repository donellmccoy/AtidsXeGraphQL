using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SectionBreakdownCode
    {
        [JsonProperty]
        public int SectionBreakdownCodeId { get; set; }
        [JsonProperty]
        public int SectionQuarter { get; set; }
        [JsonProperty]
        public int? Section16th { get; set; }
        [JsonProperty]
        public int? Section64th { get; set; }
        [JsonProperty]
        public int? Section256th { get; set; }
        //[DataMember(Name = "sectionLegal")]
        //public List<SectionLegal> SectionLegal { get; set; }
    }
}