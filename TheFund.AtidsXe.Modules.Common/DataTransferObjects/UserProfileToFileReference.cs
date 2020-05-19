using Newtonsoft.Json;
using System;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserProfileToFileReference
    {
        [JsonProperty]
        public int UserId { get; set; }
        [JsonProperty]
        public int ProfileId { get; set; }
        [JsonProperty]
        public int FileReferenceId { get; set; }
        [JsonProperty]
        public int CreatedBy { get; set; }
        [JsonProperty]
        public DateTime CreatedDate { get; set; }
        [JsonProperty]
        public int ModifiedBy { get; set; }
        [JsonProperty]
        public DateTime ModifiedDate { get; set; }
        [JsonProperty]
        public UserProfile UserProfile { get; set; }
        [JsonProperty]
        public User User { get; set; }
        [JsonProperty]
        public FileReference FileReference { get; set; }
    }
}