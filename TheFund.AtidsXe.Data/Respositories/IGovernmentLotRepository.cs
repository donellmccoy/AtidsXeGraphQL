using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IGovernmentLotRepository
    {
        Task<IDictionary<int, GovernmentLot>> GetGovernmentLotByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}