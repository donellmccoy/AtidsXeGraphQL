using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IChainOfTitleCategoryRepository
    {
        Task<IDictionary<int, ChainOfTitleCategory>> GetChainOfTitleCategoriesByIdAsync(IEnumerable<int> keys, CancellationToken token);
    }
}