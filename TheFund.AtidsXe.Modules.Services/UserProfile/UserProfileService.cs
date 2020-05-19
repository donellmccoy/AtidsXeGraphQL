using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ensure;
using ReactiveUI;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Services.Caching;
using TheFund.AtidsXe.Modules.Services.Factories;
using TheFund.AtidsXe.Modules.Services.GraphQL;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.UserProfile
{
    [Export(typeof(IUserProfileService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class UserProfileService : ServiceBase, IUserProfileService
    {
        private readonly IGraphQLService _graphQLService;
        private readonly ICachingServiceV3 _cachingService;

        [ImportingConstructor]
        public UserProfileService(IGraphQLService graphQlService, ICachingServiceV3 cachingService) : base(cachingService)
        {
            _graphQLService = graphQlService;
            _cachingService = cachingService;
        }

        public Task<IUserProfileItem> GetUserProfileAsync(int userId, int profileId, CancellationToken token = default)
        {
            return null;
        }

        public Task<IEnumerable<IUserProfileItem>> GetUserProfilesAsync(int userId, CancellationToken token = default)
        {
            return null;
        }

        public async Task<IUserProfile> CreateUserProfileAsync(IUserProfile userProfile, CancellationToken token = default)
        {
            userProfile.EnsureNotNull();

            _cachingService.ClearRegion(CacheRegions.UserProfiles);
            await _graphQLService.CreateUserProfileAsync(userProfile, token).ConfigureAwait(false);

            return userProfile;
        }

        public Task DeleteUserProfileAsync(int userId, int profileId, CancellationToken token = default)
        {
            userId.EnsureGreaterThenZero();
            profileId.EnsureGreaterThenZero();

            return Task.Run(async () =>
            {
                _cachingService.ClearRegion(CacheRegions.UserProfiles);

                await _graphQLService.DeleteUserProfileAsync(userId, profileId, token).ConfigureAwait(false);

            }, token);
        }

        public IObservable<Unit> DeleteProfile(int userId, int profileId, CancellationToken token = default)
        {
            return _graphQLService.DeleteProfile(userId, profileId, token)
                                  .AsCompletion();
        }

        public Task DeleteUserProfilesAsync(int userId, CancellationToken token = default)
        {
            userId.EnsureGreaterThenZero();

            return Task.Run(async () =>
            {
                _cachingService.ClearRegion(CacheRegions.UserProfiles);
                
                await _graphQLService.DeleteUserProfilesAsync(userId, token).ConfigureAwait(false);

            }, token);
        }

        public async Task<IUserProfile> UpdateUserProfileAsync(IUserProfile userProfile, CancellationToken token = default)
        {
            userProfile.EnsureNotNull();

            _cachingService.ClearRegion(CacheRegions.UserProfiles);

            await _graphQLService.UpdateUserProfileAsync(userProfile, token).ConfigureAwait(false);
            
            return userProfile;
        }
    }
}