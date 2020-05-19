using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IBranchLocationRepository
    {
        Task<IDictionary<int, BranchLocation>> GetBranchLocationsByIdAsync(IEnumerable<int> keys, CancellationToken token);
    }
}