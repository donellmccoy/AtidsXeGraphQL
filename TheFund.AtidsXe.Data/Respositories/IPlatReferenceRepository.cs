using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IPlatReferenceRepository
    {
        Task<IDictionary<int, PlatReference>> GetPlatReferenceByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, PlatReference>> GetPlatReferenceByIdAsync(IEnumerable<int> keys);
    }
}