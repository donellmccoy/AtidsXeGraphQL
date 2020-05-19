using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ITitleEventRepository
    {
        Task<IDictionary<int, TitleEvent>> GetTitleEventsByIdAsync(IEnumerable<int> keys, CancellationToken token);
    }
}