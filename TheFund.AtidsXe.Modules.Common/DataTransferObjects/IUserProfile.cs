using System;
using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    public interface IUserProfile
    {
        int ProfileId { get; set; }
        int UserId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        List<UserProfileToFileReference> UserProfileFileReferences { get; set; }
    }
}