using Newtonsoft.Json;
using System.Collections.Generic;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Worksheet
    {
        public Worksheet()
        {
            PolicyWorksheetItems = new List<PolicyWorksheetItem>();
            WorksheetItems = new List<WorksheetItem>();
        }
        [JsonProperty]
        public int WorksheetId { get; set; }
        [JsonProperty]
        public int FileReferenceId { get; set; }
        [JsonProperty]
        public List<PolicyWorksheetItem> PolicyWorksheetItems { get; set; }
        [JsonProperty]
        public List<WorksheetItem> WorksheetItems { get; set; }
    }
}
