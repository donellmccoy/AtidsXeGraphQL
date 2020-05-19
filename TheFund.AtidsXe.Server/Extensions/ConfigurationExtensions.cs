using Microsoft.Extensions.Configuration;

namespace TheFund.AtidsXe.Server.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string key)
        {
            return configuration.GetSection(key).Get<T>();
        }
    }
}
