using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISearchRepository
    {
        Task<IDictionary<int, Search>> GetSearchByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, Search>> GetSearchesIdAsync(IEnumerable<int> keys);
    }
}