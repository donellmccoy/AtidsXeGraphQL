using System;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Common.Response;
using JetBrains.Annotations;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Services.GraphQL
{
    public interface IGraphQLService
    {
        Task<string> GetFileReferencesAsync([NotNull] string fileReferenceName, CancellationToken token = default);
        Task<string> GetFileReferenceAsync(int fileReferenceId, CancellationToken token = default);
        
        Task<string> GetUserProfileAsync(int userId, int profileId, CancellationToken token = default);
        Task<string> GetUserProfilesAsync(int userId, CancellationToken token = default);
        Task<string> DeleteUserProfileAsync(int userId, int profileId, CancellationToken token = default);
        Task<string> DeleteUserProfilesAsync(int userId, CancellationToken token = default);
        Task<string> UpdateUserProfileAsync([NotNull] IUserProfile userProfile, CancellationToken token = default);
        Task<string> CreateUserProfileAsync([NotNull] IUserProfile userProfile, CancellationToken token = default);
        IObservable<string> DeleteProfile(int userId, int profileId, CancellationToken token = default);
        
        Task<string> GetUserFavoritesAsync(int userId, CancellationToken token = default);
        Task<string> DeleteUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default);
        Task<string> CreateUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default);
        Task<string> GetRecentFileReferencesAsync(int userId, CancellationToken token);
    }
}