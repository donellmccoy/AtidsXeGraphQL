using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PlatPropertiesGraphType : ObjectGraphTypeBase<PlatProperties>
    {
        public PlatPropertiesGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(PlatPropertiesGraphType);
            Description = nameof(PlatPropertiesGraphType);

            Field(p => p.PlatReferenceId);
            Field(p => p.CertificationDate, true);
            Field(p => p.PlatName, true);
            Field(p => p.PlatDate, true);
            Field<IntGraphType>("PostingsConform", context => context.Source.PostingsConform);
            Field<IntGraphType>("IntervalOwnership", context => context.Source.IntervalOwnership);
            Field<IntGraphType>("RetroCertified", context => context.Source.RetroCertified);
            Field(p => p.PrimaryHierarchy, true);
            Field(p => p.AlternateHierarchy1, true);
            Field(p => p.AlternateHierarchy2, true);
        }
    }
}