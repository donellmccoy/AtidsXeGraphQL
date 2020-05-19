using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;
namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IParentSearchRepository
    {
        Task<IDictionary<int, Search>> GetParentSearchByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}