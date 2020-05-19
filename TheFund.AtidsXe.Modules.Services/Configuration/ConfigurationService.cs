using System;
using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.Services.Configuration
{
    [Export(typeof(IConfigurationService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ConfigurationService : IConfigurationService
    {
        public string Environment
        {
            get
            {
#if DEBUG
                return "Development";
#else
                return "Production";
#endif
            }
        }

        public TimeSpan SearchDueTime { get; } = TimeSpan.FromMilliseconds(600);

        public bool ShowGraphQLResponseData { get; } = false;

        public int TryIntervalTime { get; } = 100;

        public int MaxTryCountLimit { get; } = 5;

        public int MaxTryTimeLimit { get; } = 3000;

        public int MaxAllowedRecentSearchTerms { get; } = 4;

        public int MaxAllowedCachedFileReferences { get; } = 5;

        public string GraphQLEndPointAddress { get; } = "http://localhost:5002/api/graphql";
    }
}
