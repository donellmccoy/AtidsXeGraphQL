namespace TheFund.AtidsXe.Server.Settings
{
    public interface IDbContextSettings
    {
        int CommandTimeout { get; set; }
        int PoolSize { get; set; }
        int MaxRetryCount { get; set; }
        int MaxRetryDelay { get; set; }
        bool EnablePooling { get; set; }
        System.TimeSpan MaxRetryDelayTimeSpan { get; }
    }
}