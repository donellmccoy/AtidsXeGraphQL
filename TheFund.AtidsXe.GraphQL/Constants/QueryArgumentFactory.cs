using GraphQL.Types;

namespace TheFund.AtidsXe.GraphQL.Constants
{
    internal static class QueryArgumentFactory
    {
        public static QueryArgument Create<TType>(string argumentName, string description) where TType : IGraphType
        {
            return new QueryArgument<TType>
            {
                Name = argumentName,
                Description = description
            };
        }
    }
}