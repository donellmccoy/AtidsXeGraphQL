using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;
namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISearchStatusRepository
    {
        Task<IDictionary<int, SearchStatus>> GetSearchStatusByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}