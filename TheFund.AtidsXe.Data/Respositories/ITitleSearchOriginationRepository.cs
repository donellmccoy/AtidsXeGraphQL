using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ITitleSearchOriginationRepository
    {
        Task<IDictionary<int, TitleSearchOrigination>> GetTitleSearchOriginationsByIdAsync(IEnumerable<int> keys, CancellationToken token);
    }
}