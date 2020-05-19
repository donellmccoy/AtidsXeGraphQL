using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ChainOfTitle : IChainOfTitle
    {
        public ChainOfTitle()
        {
            ChainOfTitleItems = new List<ChainOfTitleItem>();
            ChainOfTitleNotes = new List<ChainOfTitleNotes>();
            ChainOfTitleSearches = new List<ChainOfTitleSearch>();
        }
        [JsonProperty]
        public int ChainOfTitleId { get; set; }
        [JsonProperty]
        public int FileReferenceId { get; set; }
        [JsonProperty]
        public List<ChainOfTitleItem> ChainOfTitleItems { get; set; }
        [JsonProperty]
        public List<ChainOfTitleNotes> ChainOfTitleNotes { get; set; }
        [JsonProperty]
        public List<ChainOfTitleSearch> ChainOfTitleSearches { get; set; }
    }
}
