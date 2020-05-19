using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ITitleEventSearchRepository
    {
        Task<IDictionary<int, TitleEventSearch>> GetTitleEventSearchByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, TitleEventSearch>> GetTitleEventSearchesIdAsync(IEnumerable<int> keys);
    }
}