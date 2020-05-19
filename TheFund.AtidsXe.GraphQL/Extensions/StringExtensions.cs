namespace TheFund.AtidsXe.GraphQL.Extensions
{
    public static class StringExtensions
    {
        public static string TrimIfNotNull(this string source)
        {
            return !string.IsNullOrWhiteSpace(source) ? source.Trim() : null;
        }
    }
}
