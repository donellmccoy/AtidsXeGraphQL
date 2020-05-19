namespace TheFund.AtidsXe.Server.Settings
{
    public interface IDbConnectionStrings
    {
        SqlConnectionStrings SqlConnectionStrings { get; set; }
        NoSqlConnectionStrings NoSqlConnectionStrings { get; set; }
    }
}