using System;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class SubdivisionPlattedLegalGraphType : ObjectGraphTypeBase<SubdivisionPlattedLegal>
    {
        public SubdivisionPlattedLegalGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(SubdivisionPlattedLegalGraphType);
            Description = nameof(SubdivisionPlattedLegalGraphType);

            Field(p => p.SubdivisionLevelId);
            Field(p => p.PlatReferenceId);
            Field(p => p.SearchId);

            //Field<PlattedLegalGraphType, PlattedLegal, PlattedLegalCompositeKey>(
            //       FieldNames.PlattedLegal,
            //       p => new PlattedLegalCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId),
            //       p => new PlattedLegalCompositeKey(p.PlatReferenceId, p.SubdivisionLevelId));

            Field<PlattedLegalGraphType, PlattedLegal>(
                FieldNames.PlattedLegal,
                p => ValueTuple.Create(p.PlatReferenceId, p.SubdivisionLevelId),
                p => ValueTuple.Create(p.PlatReferenceId, p.SubdivisionLevelId));
        }
    }
}