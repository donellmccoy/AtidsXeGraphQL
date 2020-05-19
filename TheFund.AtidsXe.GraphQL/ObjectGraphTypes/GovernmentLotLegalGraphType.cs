using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class GovernmentLotLegalGraphType : ObjectGraphTypeBase<GovernmentLotLegal>
    {
        public GovernmentLotLegalGraphType(
            IDataLoaderContextAccessor accessor, 
            IGovernmentLotRepository governmentLotRepository, 
            IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(GovernmentLotLegalGraphType);
            Description = nameof(GovernmentLotLegalGraphType);

            Field(p => p.GovernmentLotId);
            Field(p => p.UnplattedReferenceId);

            Field<GovernmentLotGraphType, GovernmentLot>()
                .Name(FieldNames.GovernmentLot)
                .ResolveAsync(context => accessor.Context.GetOrAddBatchLoader(nameof(governmentLotRepository.GetGovernmentLotByKeysAsync),
                (Func<IEnumerable<int>, Task<IDictionary<int, GovernmentLot>>>)(keys => governmentLotRepository.GetGovernmentLotByKeysAsync(keys, context.CancellationToken)))
                .LoadAsync(context.Source.GovernmentLotId));

            //UnplattedReference
            //list:AcreageGovtLotLegal
            //list:PolicyGovtLotLegalMql
            //list:TitleEventGovtLotLegalMql
        }
    }
}