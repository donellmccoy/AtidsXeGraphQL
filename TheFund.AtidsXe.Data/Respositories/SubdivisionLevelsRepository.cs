using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class SubdivisionLevelsRepository : ISubdivisionLevelsRepository
    {
        private readonly ATIDSXEContext _context;

        public SubdivisionLevelsRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, SubdivisionLevels>> GetSubdivisionLevelsByIdAsync(IEnumerable<int> keys)
        {
            return (await _context.SubdivisionLevels.Where(entity => keys.Contains(entity.SubdivisionLevelId)).ToListAsync()).ToLookup(entity => entity.SubdivisionLevelId);
        }

        public async Task<IDictionary<int, SubdivisionLevels>> GetSubdivisionLevelsByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.SubdivisionLevels.Where(entity => keys.Contains(entity.SubdivisionLevelId)).ToDictionaryAsync(entity => entity.SubdivisionLevelId, token);
        }
    }
}
