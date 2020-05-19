using GraphQL.DataLoader;
using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class MinNumberGraphType : ObjectGraphType<MinNumber>
    {
        public MinNumberGraphType(IDataLoaderContextAccessor accessor)
        {
        }
    }
}