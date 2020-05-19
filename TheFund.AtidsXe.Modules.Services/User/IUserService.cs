using GraphQL.Common.Response;
using System;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Services.User
{
    public interface IUserService
    {
        Task<IUserItem> GetUserAsync();
        IObservable<IUserItem> GetUserObservable(int userId, CancellationToken token = default);
        Task<string> GetRecentFileReferencesAsync(int userId, CancellationToken token = default);
        
        Task<string> GetUserFavoritesAsync(int userId, int fileReferenceId, CancellationToken token);
        Task<string> DeleteUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default);
        Task<string> CreateUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default);
    }
}