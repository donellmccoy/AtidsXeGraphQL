using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class PlatReferenceRepository : IPlatReferenceRepository
    {
        private readonly ATIDSXEContext _context;

        public PlatReferenceRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, PlatReference>> GetPlatReferenceByIdAsync(IEnumerable<int> keys)
        {
            return (await _context.PlatReference.Where(entity => keys.Contains(entity.PlatReferenceId)).ToListAsync()).ToLookup(entity => entity.PlatReferenceId);
        }

        public async Task<IDictionary<int, PlatReference>> GetPlatReferenceByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.PlatReference
                                 .Where(entity => keys.Contains(entity.PlatReferenceId))
                                 .ToDictionaryAsync(entity => entity.PlatReferenceId, token);
        }
    }
}
