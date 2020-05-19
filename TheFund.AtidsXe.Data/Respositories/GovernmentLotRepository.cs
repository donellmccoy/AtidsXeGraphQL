using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class GovernmentLotRepository : IGovernmentLotRepository
    {
        private readonly ATIDSXEContext _context;

        public GovernmentLotRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, GovernmentLot>> GetGovernmentLotByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.GovernmentLot
                                 .Where(entity => keys.Contains(entity.GovernmentLotId))
                                 .ToDictionaryAsync(entity => entity.GovernmentLotId, token);
        }
    }
}
