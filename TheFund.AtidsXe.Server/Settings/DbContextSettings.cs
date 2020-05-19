using System;

namespace TheFund.AtidsXe.Server.Settings
{
    public class DbContextSettings : IDbContextSettings
    {
        public int CommandTimeout { get; set; }
        public int PoolSize { get; set; }
        public int MaxRetryCount { get; set; }
        public int MaxRetryDelay { get; set; }
        public TimeSpan MaxRetryDelayTimeSpan => new TimeSpan(MaxRetryDelay);
        public bool EnablePooling { get; set; }
    }
}
