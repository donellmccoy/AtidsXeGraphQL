using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FileReferenceQuery
    {
        [JsonProperty(PropertyName = "fileReferenceById")]
        public FileReference FileReference { get; set; }

        [JsonProperty(PropertyName = "fileReferencesByName")]
        public List<FileReference> FileReferences { get; set; }

        [JsonProperty(PropertyName = "userProfilesByUserId")]
        public List<UserProfile> UserProfiles { get; set; }

        [JsonProperty(PropertyName = "userProfileByUserIdAndProfileId")]
        public UserProfile UserProfile { get; set; }
    }
}
