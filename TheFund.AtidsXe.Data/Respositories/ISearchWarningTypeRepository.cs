using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISearchWarningTypeRepository
    {
        Task<ILookup<int, SearchWarningType>> GetSearchWarningTypesIdAsync(IEnumerable<int> keys);
        Task<IDictionary<int, SearchWarningType>> GetSearchWarningTypeByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}