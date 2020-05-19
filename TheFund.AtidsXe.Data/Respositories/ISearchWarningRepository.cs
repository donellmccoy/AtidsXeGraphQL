using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISearchWarningRepository
    {
        Task<IDictionary<int, SearchWarning>> GetSearchWarningByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, SearchWarning>> GetSearchWarningsIdAsync(IEnumerable<int> keys);
    }
}