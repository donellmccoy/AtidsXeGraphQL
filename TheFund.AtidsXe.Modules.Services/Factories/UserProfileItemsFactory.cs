using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class UserProfileItemsFactory
    {
        public static IEnumerable<IUserProfileItem> CreateItems(string json)
        {
            var fileReferences = JsonConvert.DeserializeObject<FileReferenceQuery>(json)?.UserProfiles;
            return fileReferences.Select(p => new UserProfileItem(p)).ToList();
        }

        public static IUserProfileItem CreateItem(string json)
        {
            var fileReference = JsonConvert.DeserializeObject<FileReferenceQuery>(json)?.UserProfile;
            return new UserProfileItem(fileReference);
        }
    }
}