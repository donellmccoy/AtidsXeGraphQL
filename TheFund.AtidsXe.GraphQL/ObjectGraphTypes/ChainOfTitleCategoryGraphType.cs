using GraphQL.Types;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class ChainOfTitleCategoryGraphType : ObjectGraphType<ChainOfTitleCategory>
    {
        public ChainOfTitleCategoryGraphType()
        {
            Name = nameof(ChainOfTitleCategoryGraphType);
            Description = nameof(ChainOfTitleCategoryGraphType);

            Field(p => p.ChainOfTitleCategoryId);
            Field(p => p.Description, true);
        }
    }
}