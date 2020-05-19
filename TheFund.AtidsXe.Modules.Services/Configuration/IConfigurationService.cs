using System;

namespace TheFund.AtidsXe.Modules.Services.Configuration
{
    public interface IConfigurationService
    {
        string Environment { get; }
        int MaxAllowedRecentSearchTerms { get; }
        int MaxAllowedCachedFileReferences { get; }
        string GraphQLEndPointAddress { get; }
        TimeSpan SearchDueTime { get; }
        bool ShowGraphQLResponseData { get; }
        int TryIntervalTime { get; }
        int MaxTryCountLimit { get; }
        int MaxTryTimeLimit { get; }
    }
}