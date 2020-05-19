using Newtonsoft.Json;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FileStatus
    {
        [JsonProperty]
        public int FileStatusId { get; set; }
        [JsonProperty]
        public string Description { get; set; }
    }
}