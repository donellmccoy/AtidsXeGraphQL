﻿using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PlattedLegal
    {
        [JsonProperty]
        public int PlatReferenceId { get; set; }
        [JsonProperty]
        public int SubdivisionLevelId { get; set; }
        [JsonProperty]
        public PlatReference PlatReference { get; set; }
        [JsonProperty]
        public SubdivisionLevels SubdivisionLevel { get; set; }
    }

    //[DataContract]
    //public class AcreageGovtLotLegal
    //{
    //    [DataMember(Name = "searchId")]
    //    public int SearchId { get; set; }
    //    [DataMember(Name = "governmentLotId")]
    //    public int GovernmentLotId { get; set; }
    //    [DataMember(Name = "unplattedReferenceId")]
    //    public int UnplattedReferenceId { get; set; }
    //    [DataMember(Name = "governmentLotLegal")]
    //    public GovernmentLotLegal GovernmentLotLegal { get; set; }
    //}

    //[DataContract]
    //public class GovernmentLotLegal
    //{
    //    public GovernmentLotLegal()
    //    {
    //        AcreageGovtLotLegal = new List<AcreageGovtLotLegal>();
    //        PolicyGovtLotLegalMql = new List<PolicyGovtLotLegalMql>();
    //        TitleEventGovtLotLegalMql = new List<TitleEventGovtLotLegalMql>();
    //    }

    //    [DataMember(Name = "unplattedReferenceId")]
    //    public int UnplattedReferenceId { get; set; }
    //    [DataMember(Name = "governmentLotId")]
    //    public int GovernmentLotId { get; set; }
    //    [DataMember(Name = "governmentLot")]
    //    public GovernmentLot GovernmentLot { get; set; }
    //    [DataMember(Name = "unplattedReference")]
    //    public UnplattedReference UnplattedReference { get; set; }
    //    [DataMember(Name = "acreageGovtLotLegal")]
    //    public List<AcreageGovtLotLegal> AcreageGovtLotLegal { get; set; }
    //    [DataMember(Name = "policyGovtLotLegalMql")]
    //    public List<PolicyGovtLotLegalMql> PolicyGovtLotLegalMql { get; set; }
    //    [DataMember(Name = "titleEventGovtLotLegalMql")]
    //    public List<TitleEventGovtLotLegalMql> TitleEventGovtLotLegalMql { get; set; }
    //}

    //[DataContract]
    //public class AcreageSectionLegal
    //{
    //    [DataMember(Name = "searchId")]
    //    public int SearchId { get; set; }
    //    [DataMember(Name = "sectionBreakdownCodeId")]
    //    public int SectionBreakdownCodeId { get; set; }
    //    [DataMember(Name = "unplattedReferenceId")]
    //    public int UnplattedReferenceId { get; set; }
    //    [DataMember(Name = "sectionLegal")]
    //    public SectionLegal SectionLegal { get; set; }
    //}


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
