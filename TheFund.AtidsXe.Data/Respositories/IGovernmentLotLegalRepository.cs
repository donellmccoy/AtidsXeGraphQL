using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IGovernmentLotLegalRepository
    {
        Task<IDictionary<GovernmentLotLegalCompositeKey, GovernmentLotLegal>> GovernmentLotLegalByKeysAsync(IEnumerable<GovernmentLotLegalCompositeKey> keys, CancellationToken token);
    }
}