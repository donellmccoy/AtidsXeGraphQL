using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyWorksheetItemGraphType : ObjectGraphTypeBase<PolicyWorksheetItem>
    {
        public PolicyWorksheetItemGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(PolicyWorksheetItemGraphType);
            Description = nameof(PolicyWorksheetItemGraphType);

            Field(p => p.PolicyId);
            Field(p => p.WorksheetId);
            Field(x => x.Sequence);

			Field<PolicyGraphType, Policy>(
                FieldNames.Policy,
                p => p.PolicyId,
                p => p.PolicyId);

			Field<WorksheetGraphType, Worksheet>(
                FieldNames.Worksheet,
                p => p.WorksheetId,
                p => p.WorksheetId);
        }
    }
}
