using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyTitleStatusReportGraphType : ObjectGraphTypeBase<PolicyTitleStatusReport>
    {
        public PolicyTitleStatusReportGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(PolicyTitleStatusReportGraphType);
            Description = nameof(PolicyTitleStatusReportGraphType);

            Field(p => p.SearchId);
            Field(p => p.TitleStatusReportCode);
            Field(p => p.TitleStatusReportNumber);
        }
    }
}