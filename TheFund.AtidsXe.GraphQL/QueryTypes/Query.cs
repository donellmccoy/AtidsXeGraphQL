using GraphQL.Types;

namespace TheFund.AtidsXe.GraphQL.QueryTypes
{
    public sealed class Query : ObjectGraphType
    {
        public Query()
        {
            Name = "Query";
            Field<FileReferenceQuery>("FileReferenceQuery", resolve: context => new { });
        }
    }
}