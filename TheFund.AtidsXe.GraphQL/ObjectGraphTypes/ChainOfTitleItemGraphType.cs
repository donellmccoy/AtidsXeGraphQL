using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class ChainOfTitleItemGraphType : ObjectGraphTypeBase<ChainOfTitleItem>
    {
        public ChainOfTitleItemGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(ChainOfTitleItemGraphType);
            Description = nameof(ChainOfTitleItemGraphType);

            Field(p => p.ChainOfTitleItemId);
            Field(p => p.ChainOfTitleId);
            Field(p => p.TitleEventId);
            Field(p => p.ChainOfTitleCategoryId);
            Field(p => p.ParentTitleEventId, true);
            Field(p => p.OrderIndex);

            Field<IntGraphType, int>()
                .Name(FieldNames.UserModified).Resolve(context => context.Source.UserModified);
            Field<IntGraphType, int>()
                .Name(FieldNames.StartingTitleEvent).Resolve(context => context.Source.StartingTitleEvent);

            Field<TitleEventGraphType, TitleEvent>(
                FieldNames.TitleEvent,
                chainOfTitleItem => chainOfTitleItem.TitleEventId,
                titleEvent => titleEvent.TitleEventId);

            Field<ChainOfTitleCategoryGraphType, ChainOfTitleCategory>(
                FieldNames.ChainOfTitleCategory,
                chainOfTitleItem => chainOfTitleItem.ChainOfTitleCategoryId,
                chainOfTitleCategory => chainOfTitleCategory.ChainOfTitleCategoryId);
        }
    }
}