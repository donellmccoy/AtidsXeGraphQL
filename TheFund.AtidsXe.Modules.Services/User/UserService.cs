using GraphQL.Common.Response;
using ReactiveUI;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Services.Caching;
using TheFund.AtidsXe.Modules.Services.GraphQL;

namespace TheFund.AtidsXe.Modules.Services.User
{
    [Export(typeof(IUserService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class UserService : IUserService
    {
        #region Fields

        private readonly IGraphQLService _graphQLService;
        private readonly ICachingService _cachingService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public UserService(IGraphQLService graphQlService, ICachingService cachingService)
        {
            _graphQLService = graphQlService;
            _cachingService = cachingService;
        }

        #endregion

        #region User Favorite File References

        public async Task InitializeFavoritesAsync(int userId)
        {
            var response = await _cachingService.AddOrGetExistingAsync
            (
                userId,
                CacheRegions.UserFavorites,
                () => _graphQLService.GetUserFavoritesAsync(1)
            ).ConfigureAwait(false);
        }

        public async Task<string> GetUserFavoritesAsync(int userId, int fileReferenceId, CancellationToken token = default)
        {
            var response = await _cachingService.AddOrGetExistingAsync
            (
                userId,
                CacheRegions.FileReferences,
                () => _graphQLService.GetUserFavoritesAsync(userId, token)
            ).ConfigureAwait(false);

            return response;
        }

        public async Task<string> DeleteUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default)
        {
            var response = await _cachingService.RemoveAsync
            (
                userId,
                CacheRegions.FileReferences,
                () => _graphQLService.DeleteUserFavoriteAsync(userId, fileReferenceId, token)
            ).ConfigureAwait(false);

            return null;
        }

        public async Task<string> CreateUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default)
        {
            var response = await _cachingService.AddOrGetExistingAsync
            (
                userId,
                CacheRegions.FileReferences,
                () => _graphQLService.CreateUserFavoriteAsync(userId, fileReferenceId, token)
            ).ConfigureAwait(false);

            return response;
        }

        #endregion

        #region User Recent File References

        public async Task<string> GetRecentFileReferencesAsync(int userId, CancellationToken token = default)
        {
            var response = await _cachingService.AddOrGetExistingAsync
            (
                userId,
                CacheRegions.FileReferences,
                () => _graphQLService.GetRecentFileReferencesAsync(userId, token)
            )
            .ConfigureAwait(false);

            return response;
        }

        public async Task<string> DeleteRecentFileReferenceAsync(int userId, int fileReferenceId, CancellationToken token = default)
        {
            await Task.Delay(1000, token).ConfigureAwait(false);

            return null;
        }

        public async Task<string> CreateRecentFileReferenceAsync(int userId, int fileReferenceId, CancellationToken token = default)
        {
            await Task.Delay(1000, token).ConfigureAwait(false);

            return null;
        }

        #endregion

        #region User Information

        public Task<IUserItem> GetUserAsync()
        {
            IUserItem userItem = new UserItem
            {
                FirstName = "Donell",
                LastName = "McCoy",
                UserId = 1,
                UserName = "dxmcc"
            };

            return Task.FromResult(userItem);
        }

        public IObservable<IUserItem> GetUserObservable(int userId, CancellationToken token = default)
        {
            return Observable.FromAsync<IUserItem>(() =>
            {
                var userItem = new UserItem
                {
                    FirstName = "Donell",
                    LastName = "McCoy",
                    UserId = userId,
                    UserName = "dxmcc"
                };

                return Task.FromResult<IUserItem>(userItem);

            }, RxApp.TaskpoolScheduler);
        }

		#endregion
    }
}
