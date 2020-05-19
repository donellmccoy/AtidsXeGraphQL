using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class BranchLocationGraphType : ObjectGraphTypeBase<BranchLocation>
    {
        public BranchLocationGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(BranchLocationGraphType);
            Description = nameof(BranchLocationGraphType);

            Field(p => p.BranchLocationId);
            Field(p => p.AccountNumber, true);
            Field(p => p.Description, true);
            Field<IntGraphType>(FieldNames.IsInternal, context => context.Source.IsInternal);
            FieldListAsync<FileReferenceGraphType, FileReference>(
                FieldNames.FileReferences,
                p => p.BranchLocationId,
                p => p.BranchLocationId);
        }
    }
}