using Newtonsoft.Json;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AcreageGovtLotLegal
    {
        [JsonProperty]
        public int SearchId { get; set; }
        [JsonProperty]
        public int GovernmentLotId { get; set; }
        [JsonProperty]
        public int UnplattedReferenceId { get; set; }
        //[JsonProperty]
        //public GovernmentLotLegal GovernmentLotLegal { get; set; }
    }


    //[DataContract]
    //public class SectionLegal
    //{
    //    public SectionLegal()
    //    {
    //        AcreageSectionLegal = new List<AcreageSectionLegal>();
    //        PolicySectionLegalMql = new List<PolicySectionLegalMql>();
    //        TitleEventSectionLegalMql = new List<TitleEventSectionLegalMql>();
    //    }

    //    [DataMember(Name = "plattedLegal")]
    //    public int SectionBreakdownCodeId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public int UnplattedReferenceId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public SectionBreakdownCode SectionBreakdownCode { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public UnplattedReference UnplattedReference { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<AcreageSectionLegal> AcreageSectionLegal { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<PolicySectionLegalMql> PolicySectionLegalMql { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<TitleEventSectionLegalMql> TitleEventSectionLegalMql { get; set; }
    //}

    //[DataContract]
    //public class UnplattedReference
    //{
    //    public UnplattedReference()
    //    {
    //        GovernmentLotLegal = new List<GovernmentLotLegal>();
    //        SectionLegal = new List<SectionLegal>();
    //    }

    //    [DataMember(Name = "plattedLegal")]
    //    public int UnplattedReferenceId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public string Meridian { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public string Range { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public int RangeDirectionTypeId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public string Township { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public int TownshipDirectionTypeId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public string Section { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public int BreakdownCodeTypeId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public BreakdownCodeType BreakdownCodeType { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public RangeDirectionType RangeDirectionType { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public TownshipDirectionType TownshipDirectionType { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<GovernmentLotLegal> GovernmentLotLegal { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<SectionLegal> SectionLegal { get; set; }
    //}

    //[DataContract]
    //public class BreakdownCodeType
    //{
    //    public BreakdownCodeType()
    //    {
    //        UnplattedReference = new List<UnplattedReference>();
    //    }

    //    [DataMember(Name = "plattedLegal")]
    //    public int BreakdownCodeTypeId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public string Description { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<UnplattedReference> UnplattedReference { get; set; }
    //}

    //[DataContract]
    //public class RangeDirectionType
    //{
    //    public RangeDirectionType()
    //    {
    //        UnplattedReference = new List<UnplattedReference>();
    //    }

    //    [DataMember(Name = "plattedLegal")]
    //    public int RangeDirectionTypeId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public string Description { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<UnplattedReference> UnplattedReference { get; set; }
    //}

    //[DataContract]
    //public class TownshipDirectionType
    //{
    //    public TownshipDirectionType()
    //    {
    //        UnplattedReference = new List<UnplattedReference>();
    //    }

    //    [DataMember(Name = "plattedLegal")]
    //    public int TownshipDirectionTypeId { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public string Description { get; set; }
    //    [DataMember(Name = "plattedLegal")]
    //    public List<UnplattedReference> UnplattedReference { get; set; }
    //}
}
