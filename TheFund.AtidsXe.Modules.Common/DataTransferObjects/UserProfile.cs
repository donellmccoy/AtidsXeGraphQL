using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserProfile : IUserProfile
    {
        [JsonProperty]
        public int ProfileId { get; set; }
        [JsonProperty]
        public int UserId { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public int CreatedBy { get; set; }
        [JsonProperty]
        public DateTime CreatedDate { get; set; }
        [JsonProperty]
        public int ModifiedBy { get; set; }
        [JsonProperty]
        public DateTime ModifiedDate { get; set; }
        [JsonProperty]
        public User User { get; set; }
        [JsonProperty]
        public List<UserProfileToFileReference> UserProfileFileReferences { get; set; }
    }
}