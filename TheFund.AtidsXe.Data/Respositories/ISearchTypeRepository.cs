using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISearchTypeRepository
    {
        Task<ILookup<int, Search>> GetSearchesIdAsync(IEnumerable<int> keys);
        Task<IDictionary<int, SearchType>> GetSearchTypeByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}