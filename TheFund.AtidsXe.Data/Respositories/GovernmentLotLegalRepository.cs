using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class GovernmentLotLegalRepository : IGovernmentLotLegalRepository
    {
        private readonly ATIDSXEContext _context;

        public GovernmentLotLegalRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<GovernmentLotLegalCompositeKey, GovernmentLotLegal>> GovernmentLotLegalByKeysAsync(IEnumerable<GovernmentLotLegalCompositeKey> keys, CancellationToken token)
        {
            return await _context.GovernmentLotLegal
                                 .Where(entity => keys.Select(compositeKey => compositeKey.UnPlattedReferenceId).Contains(entity.UnplattedReferenceId) &&
                                                  keys.Select(compositeKey => compositeKey.GovernmentLotId).Contains(entity.GovernmentLotId))
                                 .ToDictionaryAsync(entity => new GovernmentLotLegalCompositeKey(entity.UnplattedReferenceId, entity.GovernmentLotId), token);
        }
    }
}
