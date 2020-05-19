using GraphQL.Types;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class GeographicLocaleGraphType : ObjectGraphType<GeographicLocale>
    {
        public GeographicLocaleGraphType()
        {
            Field(x => x.GeographicLocaleTypeId);
            Field(x => x.GeographicLocaleId);
            Field(x => x.LocaleAbbreviation, true);
            Field(x => x.LocaleName, true);
            Field(x => x.ParentGeographicLocaleId, true);
        }
    }
}