using Ensure;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using JetBrains.Annotations;
using Retry;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Services.Configuration;
using TheFund.AtidsXe.Modules.Services.Constants;
using TheFund.AtidsXe.Modules.Services.Factories;
using TheFund.AtidsXe.Modules.Services.Logging;

namespace TheFund.AtidsXe.Modules.Services.GraphQL
{
    [Export(typeof(IGraphQLService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class GraphQLService : IGraphQLService
    {
        #region Fields

        private const string QUERY_NAMES_HEADER = "QueryNames";
        private readonly ILoggingService _loggingService;
        private readonly IConfigurationService _configurationService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public GraphQLService(ILoggingService loggingService, IConfigurationService configurationService)
        {
            _loggingService = loggingService;
            _configurationService = configurationService;
        }

        #endregion

        #region Search Methods

        public async Task<string> GetFileReferencesAsync(string fileReferenceName, CancellationToken token = default)
        {
            fileReferenceName.EnsureNotNullOrWhitespace();

            var response = await PostAsync(Properties.Settings.Default.GetFileReferencesByNameQueryId, token, (QueryVariableNames.FileReferenceName, fileReferenceName))
								.ConfigureAwait(false);
            
            return response?.Data?.ToString() as string;
        }

        public async Task<string> GetFileReferenceAsync(int fileReferenceId, CancellationToken token = default)
        {
            fileReferenceId.EnsureGreaterThenZero();

            var response = await PostAsync(Properties.Settings.Default.GetFileReferenceByIdQueryId, token, (QueryVariableNames.FileReferenceId, fileReferenceId))
								.ConfigureAwait(false);
            
            return response?.Data?.ToString() as string;
        }

        #endregion

        #region User Favorite Methods

        public async Task<string> GetUserFavoritesAsync(int userId, CancellationToken token)
        {
            var response = await PostAsync
            (
                "get_query",
                token,
                (QueryVariableNames.UserId, userId)).ConfigureAwait(false);

            return response?.Data?.ToString() as string;
        }

        public async Task<string> DeleteUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default)
        {
            var response = await PostAsync(
                "delete_query", 
                token, 
                (QueryVariableNames.UserId, userId), 
                (QueryVariableNames.FileReferenceId, fileReferenceId)).ConfigureAwait(false);

            return response?.Data?.ToString() as string;
        }

        public async Task<string> CreateUserFavoriteAsync(int userId, int fileReferenceId, CancellationToken token = default)
        {
            var response = await PostAsync(
                "create_query",
                token,
                (QueryVariableNames.UserId, userId),
                (QueryVariableNames.FileReferenceId, fileReferenceId)).ConfigureAwait(false);

            return response?.Data?.ToString() as string;
        }

        #endregion

        public Task<string> GetRecentFileReferencesAsync(int userId, CancellationToken token = default)
        {
            return null;
        }

        #region Profile Methods

        public async Task<string> GetUserProfileAsync(int userId, int profileId, CancellationToken token = default)
        {
            userId.EnsureGreaterThenZero();
            profileId.EnsureGreaterThenZero();

            GraphQLResponse response;

            using (var client = GraphQLClientFactory.Create(_configurationService.GraphQLEndPointAddress, (QUERY_NAMES_HEADER, QueryNames.UserProfile)))
            {
                response = await RetryHelper.Instance.Try(async () => await client.PostAsync
                (
                    GraphQLRequestFactory.Create(Properties.Settings.Default.GetUserProfileQueryString, (QueryVariableNames.UserId, userId), (QueryVariableNames.ProfileId, profileId)),
                    token
                ))
                .WithTryInterval(_configurationService.TryIntervalTime)
                .WithMaxTryCount(_configurationService.MaxTryCountLimit)
                .WithTimeLimit(_configurationService.MaxTryTimeLimit)
                .Until(res => !HasErrors(res))
                .ConfigureAwait(false);
            }

            return response?.Data?.ToString();
        }

        public Task<string> GetUserProfilesAsync(int userId, CancellationToken token = default)
        {
            userId.EnsureGreaterThenZero();

            return Task.Run(async () =>
            {
                GraphQLResponse response;

                using (var client = GraphQLClientFactory.Create(_configurationService.GraphQLEndPointAddress, (QUERY_NAMES_HEADER, QueryNames.UserProfiles)))
                {
                    response = await RetryHelper.Instance.Try(async () => await client.PostAsync
                    (
                        GraphQLRequestFactory.Create(Properties.Settings.Default.GetUserProfilesQueryString, (QueryVariableNames.UserId, userId)),
                        token
                    ))
                    .WithTryInterval(_configurationService.TryIntervalTime)
                    .WithMaxTryCount(_configurationService.MaxTryCountLimit)
                    .WithTimeLimit(_configurationService.MaxTryTimeLimit)
                    .Until(res => !HasErrors(res))
                    .ConfigureAwait(false);
                }

                return response?.Data?.ToString() as string;

            }, token);
        }

        public Task<string> DeleteUserProfileAsync(int userId, int profileId, CancellationToken token = default)
        {
            userId.EnsureGreaterThenZero();
            profileId.EnsureGreaterThenZero();

            return Task.Run(async () =>
            {
                GraphQLResponse response;

                using (var client = GraphQLClientFactory.Create(_configurationService.GraphQLEndPointAddress, (QUERY_NAMES_HEADER, QueryNames.UserProfile)))
                {
                    response = await RetryHelper.Instance.Try(async () => await client.PostAsync
                    (
                        GraphQLRequestFactory.Create(Properties.Settings.Default.DeleteProfileQueryString, (QueryVariableNames.UserId, userId), (QueryVariableNames.ProfileId, profileId)),
                        token
                    ))
                    .WithTryInterval(_configurationService.TryIntervalTime)
                    .WithMaxTryCount(_configurationService.MaxTryCountLimit)
                    .WithTimeLimit(_configurationService.MaxTryTimeLimit)
                    .Until(res => !HasErrors(res))
                    .ConfigureAwait(false);
                }

                return response?.Data?.ToString() as string;

            }, token);
        }

        public IObservable<string> DeleteProfile(int userId, int profileId, CancellationToken token = default)
        {
            userId.EnsureGreaterThenZero();
            profileId.EnsureGreaterThenZero();

            var request = GraphQLRequestFactory.Create
            (
                Properties.Settings.Default.DeleteProfileQueryString,
                (QueryVariableNames.UserId, userId),
                (QueryVariableNames.ProfileId, profileId)
            );

            return PostRequestObservable(request, token);
        }

        public async Task<string> DeleteUserProfilesAsync(int userId, CancellationToken token = default)
        {
            userId.EnsureGreaterThenZero();

            GraphQLResponse response;

            using (var client = GraphQLClientFactory.Create(_configurationService.GraphQLEndPointAddress, (QUERY_NAMES_HEADER, QueryNames.UserProfile)))
            {
                response = await RetryHelper.Instance.Try(async () => await client.PostAsync
                    (
                        GraphQLRequestFactory.Create(Properties.Settings.Default.GetDeleteUserProfilesQueryString, (QueryVariableNames.UserId, userId)),
                        token
                    ))
                    .WithTryInterval(_configurationService.TryIntervalTime)
                    .WithMaxTryCount(_configurationService.MaxTryCountLimit)
                    .WithTimeLimit(_configurationService.MaxTryTimeLimit)
                    .Until(res => !HasErrors(res))
                    .ConfigureAwait(false);
            }

            return response?.Data?.ToString();
        }

        public async Task<string> UpdateUserProfileAsync(IUserProfile userProfile, CancellationToken token = default)
        {
            return await Task.FromResult<string>(null);
        }

        public async Task<string> CreateUserProfileAsync(IUserProfile userProfile, CancellationToken token = default)
        {
            return await Task.FromResult<string>(null);
        }

        #endregion

        #region Helper Methods

        private async Task<GraphQLResponse> PostAsync([NotNull] string queryId, CancellationToken token = default, params (string, object)[] variables)
        {
            GraphQLResponse response;

            using (var client = GraphQLClientFactory.Create(_configurationService.GraphQLEndPointAddress))
            {
                response = await RetryHelper.Instance
                            .Try(async () =>
                            {
                                return await client.PostAsync(GraphQLRequestFactory.Create(queryId, variables), token).ConfigureAwait(false);
                            })
                            .WithTryInterval(_configurationService.TryIntervalTime)
                            .WithMaxTryCount(_configurationService.MaxTryCountLimit)
                            .WithTimeLimit(_configurationService.MaxTryTimeLimit)
                            .OnSuccess(async (resp, retryAttempts) => await LogSuccessMessageAsync(resp, retryAttempts).ConfigureAwait(false))
                            .OnFailure(async (resp, retryAttempts) => await LogFailureMessageAsync(resp, retryAttempts).ConfigureAwait(false))
                            .Until(res => !HasErrors(res)).ConfigureAwait(false);
            }

            return response;
        }

        private static bool HasErrors(GraphQLResponse response)
        {
            return response?.Errors?.Any() == true;
        }

        private Task LogSuccessMessageAsync(GraphQLResponse response, int retryAttempts)
        {
            return _loggingService.LogEntryAsync(CreateSuccessMessage(response, retryAttempts));
        }

        private Task LogFailureMessageAsync(GraphQLResponse response, int retryAttempts)
        {
            return _loggingService.LogEntryAsync(CreateErrorMessage(response, retryAttempts));
        }

        private string CreateSuccessMessage(GraphQLResponse response, int retryAttempts)
        {
            return _configurationService.ShowGraphQLResponseData ? 
                $"Retry attempts: {retryAttempts}\nData: {response.Data.ToString()}" : 
                $"Retry attempts: {retryAttempts}";
        }

        private static string CreateErrorMessage(GraphQLResponse response, int retryAttempts)
        {
            return $"Retry attempts: {retryAttempts}\nErrors: {string.Join(",", response.Errors.Select(e => e.Message))}";
        }

        private IObservable<string> PostRequestObservable(GraphQLRequest request, CancellationToken token = default)
        {
            return Observable.FromAsync(async () =>
            {
                GraphQLResponse response;
                using (var client = GraphQLClientFactory.Create(_configurationService.GraphQLEndPointAddress))
                {
                    response = await client.PostAsync(request, token);
                }
                return response?.Data?.ToString() as string;
            });
        }

        #endregion
    }
}
