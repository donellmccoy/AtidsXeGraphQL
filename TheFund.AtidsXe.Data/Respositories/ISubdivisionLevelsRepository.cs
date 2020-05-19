using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISubdivisionLevelsRepository
    {
        Task<IDictionary<int, SubdivisionLevels>> GetSubdivisionLevelsByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, SubdivisionLevels>> GetSubdivisionLevelsByIdAsync(IEnumerable<int> keys);
    }
}