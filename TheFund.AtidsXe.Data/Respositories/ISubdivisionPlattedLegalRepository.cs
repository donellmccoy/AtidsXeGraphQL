using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISubdivisionPlattedLegalRepository
    {
        Task<IDictionary<int, SubdivisionPlattedLegal>> GetSubdivisionPlattedLegalByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, SubdivisionPlattedLegal>> GetSubdivisionPlattedLegalsByIdAsync(IEnumerable<int> keys);
    }
}