using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventSearchGraphType : ObjectGraphTypeBase<TitleEventSearch>
    {
        public TitleEventSearchGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Field(p => p.TitleEventId);
            Field(p => p.SearchId);

            Field<TitleEventGraphType, TitleEvent>(
                FieldNames.TitleEvent,
                p => p.TitleEventId,
                p => p.TitleEventId);
        }
    }
}