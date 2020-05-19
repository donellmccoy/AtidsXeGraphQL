using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class GeographicLocaleTypeGraphType : ObjectGraphTypeBase<GeographicLocaleType>
    {
        public GeographicLocaleTypeGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(GeographicLocaleTypeGraphType);
            Description = nameof(GeographicLocaleTypeGraphType);

            Field(p => p.GeographicLocaleTypeId);
            Field(p => p.TypeName, true);
        }
    }
}