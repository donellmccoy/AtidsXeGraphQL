using GraphQL.DataLoader;
using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class NameSearchParametersGraphType : ObjectGraphTypeBase<NameSearchParameters>
    {
        public NameSearchParametersGraphType(IDataLoaderContextAccessor accessor, IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(NameSearchParametersGraphType);
            Description = nameof(NameSearchParametersGraphType);

            Field(p => p.SearchId);
            Field(p => p.LegalEntityNameId);
            Field(p => p.LegalFilter);
            Field(p => p.OwnerBuyerRelationshipId);

            Field<IntGraphType>("FirstNamePctOfLikeness", context => context.Source.FirstNamePctOfLikeness);
            Field<IntGraphType>("FlipNames", context => context.Source.FlipNames);
            Field<IntGraphType>("LastNamePctOfLikeness", context => context.Source.LastNamePctOfLikeness);
            Field<IntGraphType>("SearchGiNames", context => context.Source.SearchGiNames);
            Field<IntGraphType>("SearchGranteeNames", context => context.Source.SearchGranteeNames);
            Field<IntGraphType>("SearchGrantorNames", context => context.Source.SearchGrantorNames);
            Field<IntGraphType>("SearchNickNames", context => context.Source.SearchNickNames);
            Field<IntGraphType>("SearchSimilarSoundingNames", context => context.Source.SearchSimilarSoundingNames);

            //LegalEntityName
            //OwnerBuyerRelationship
        }
    }
}