using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Services.Models
{
    public sealed class UserProfileItem : IUserProfileItem
    {
        public UserProfileItem(IUserProfile userProfile)
        {
            UserProfile = userProfile;
        }
        public IUserProfile UserProfile { get; }
    }
}