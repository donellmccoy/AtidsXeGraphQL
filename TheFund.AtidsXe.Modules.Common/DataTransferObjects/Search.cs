using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Search : ISearch
    {
        public Search()
        {
            //TitleEventSearches = new List<TitleEventSearch>();
            //SubdivisionPlattedLegals = new List<SubdivisionPlattedLegal>();
        }

        [JsonProperty]
        public int SearchId { get; set; }

        [JsonProperty]
        public int FileReferenceId { get; set; }

        [JsonProperty]
        public string SearchReference { get; set; }

        [JsonProperty]
        public DateTime DateOfSearch { get; set; }

        [JsonProperty]
        public DateTime SearchFromDate { get; set; }

        [JsonProperty]
        public DateTime SearchThruDate { get; set; }

        [JsonProperty]
        public int SearchTypeId { get; set; }

        [JsonProperty]
        public int GeographicLocaleId { get; set; }

        [JsonProperty]
        public int? GeographicCertRangeId { get; set; }

        [JsonProperty]
        public int? GiCertRangeId { get; set; }

        [JsonProperty]
        public int? GrantorCertRangeId { get; set; }

        [JsonProperty]
        public int? ParentSearchId { get; set; }

        [JsonProperty]
        public int? SearchStatusId { get; set; }

        [JsonProperty]
        public string InstrumentFilters { get; set; }

        [JsonProperty]
        public byte? LrsSearch { get; set; }

        [JsonProperty]
        public byte? InclMortgageeShortForm { get; set; }

        [JsonProperty]
        public byte? Hidden { get; set; }

        [JsonProperty]
        public List<TitleEventSearch> TitleEventSearches { get; set; }

        [JsonProperty]
        public List<SubdivisionPlattedLegal> SubdivisionPlattedLegals { get; set; }
        [JsonProperty]
        public List<AcreageGovtLotLegal> AcreageGovtLotLegals { get; set; }
        [JsonProperty]
        public List<AcreageSectionLegal> AcreageSectionLegals { get; set; }
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

    [JsonObject(MemberSerialization.OptIn)]
    public class BreakdownCodeType
    {
        public BreakdownCodeType()
        {
            //UnplattedReference = new List<UnplattedReference>();
        }

        [JsonProperty]
        public int BreakdownCodeTypeId { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        //[JsonProperty]
        //public List<UnplattedReference> UnplattedReference { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class RangeDirectionType
    {
        public RangeDirectionType()
        {
            //UnplattedReference = new List<UnplattedReference>();
        }

        [JsonProperty]
        public int RangeDirectionTypeId { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        //[JsonProperty]
        //public List<UnplattedReference> UnplattedReference { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TownshipDirectionType
    {
        public TownshipDirectionType()
        {
            //UnplattedReference = new List<UnplattedReference>();
        }

        [JsonProperty]
        public int TownshipDirectionTypeId { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        //[JsonProperty]
        //public List<UnplattedReference> UnplattedReference { get; set; }
    }
}
