using System;
using System.Collections.Generic;
using Telerik.Windows.Data;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Factories
{
    public static class ProfileListItemFactory
    {
        public static IProfileListItem Create(
            int userId, 
            int profileId, 
            string name, 
            string description, 
            int createdBy, 
            DateTime createdDate, 
            int modifiedBy, 
            DateTime modifiedDate,
            IEnumerable<FileReference> fileReferences)
        {
            var profileListItem = new ProfileListItem
            {
                UserId = userId,
                ProfileId = profileId,
                ProfileName = name,
                Description = description,
                CreatedBy = createdBy,
                CreatedDate = createdDate,
                ModifiedBy = modifiedBy,
                ModifiedDate = modifiedDate
            };

            profileListItem.FileReferences.AddRange(fileReferences);

            return profileListItem;
        }
    }
}