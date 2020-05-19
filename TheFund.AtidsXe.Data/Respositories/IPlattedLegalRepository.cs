using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IPlattedLegalRepository
    {
        Task<ILookup<int, PlattedLegal>> GetPlattedLegalsByIdAsync(IEnumerable<int> keys);
        Task<IDictionary<int, PlattedLegal>> GetPlattedLegalByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<IDictionary<PlattedLegalCompositeKey, PlattedLegal>> GetPlattedLegalByKeysAsync(IEnumerable<PlattedLegalCompositeKey> keys, CancellationToken token);
    }
}