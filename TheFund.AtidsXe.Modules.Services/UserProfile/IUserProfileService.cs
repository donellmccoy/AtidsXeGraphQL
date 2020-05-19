using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.UserProfile
{
    public interface IUserProfileService
    {
        Task<IUserProfileItem> GetUserProfileAsync(int userId, int profileId, CancellationToken token = default);
        Task<IEnumerable<IUserProfileItem>> GetUserProfilesAsync(int userId, CancellationToken token = default);
        Task<IUserProfile> CreateUserProfileAsync(IUserProfile userProfile, CancellationToken token = default);
        Task DeleteUserProfileAsync(int userId, int profileId, CancellationToken token = default);
        Task DeleteUserProfilesAsync(int userId, CancellationToken token = default);
        Task<IUserProfile> UpdateUserProfileAsync(IUserProfile userProfile, CancellationToken token = default);
        IObservable<Unit> DeleteProfile(int userId, int profileId, CancellationToken token = default);
    }
}