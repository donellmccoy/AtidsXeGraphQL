namespace TheFund.AtidsXe.Server.Settings
{
    public class DbConnectionStrings : IDbConnectionStrings
    {
        public SqlConnectionStrings SqlConnectionStrings { get; set; }
        public NoSqlConnectionStrings NoSqlConnectionStrings { get; set; }
    }
}
