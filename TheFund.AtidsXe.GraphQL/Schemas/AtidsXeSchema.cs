using GraphQL;
using GraphQL.Types;
using TheFund.AtidsXe.GraphQL.Mutations;
using TheFund.AtidsXe.GraphQL.QueryTypes;

namespace TheFund.AtidsXe.GraphQL.Schemas
{
    public sealed class AtidsXeSchema : Schema
    {
        public AtidsXeSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<FileReferenceQuery>();
            Mutation = resolver.Resolve<FileReferenceMutation>();
        }
    }
}
