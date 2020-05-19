using GraphQL.Types;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class FileStatusGraphType : ObjectGraphType<FileStatus>
    {
        public FileStatusGraphType()
        {
            Name = nameof(FileStatusGraphType);
            Description = nameof(FileStatusGraphType);

            Field(p => p.FileStatusId);
            Field(p => p.Description);
        }
    }
}