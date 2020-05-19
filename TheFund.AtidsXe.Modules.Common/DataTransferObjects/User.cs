using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User
    {
        [JsonProperty]
        public int UserId { get; set; }
        [JsonProperty]
        public string FirstName { get; set; }
        [JsonProperty]
        public string MiddleName { get; set; }
        [JsonProperty]
        public string LastName { get; set; }
        [JsonProperty]
        public string UserName { get; set; }
        [JsonProperty]
        public DateTime CreatedDate { get; set; }
        [JsonProperty]
        public int CreatedBy { get; set; }
        [JsonProperty]
        public int ModifiedBy { get; set; }
        [JsonProperty]
        public DateTime ModifiedDate { get; set; }
        [JsonProperty]
        public List<UserProfile> UserProfiles { get; set; }
    }
}