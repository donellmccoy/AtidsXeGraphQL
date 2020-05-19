using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventPlattedLegalMqlGraphType : ObjectGraphTypeBase<TitleEventPlattedLegalMql>
    {
        public TitleEventPlattedLegalMqlGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Field(p => p.TitleEventId);
            Field(p => p.SubdivisionLevelId);
            Field(p => p.PlatReferenceId);
        }
    }
}