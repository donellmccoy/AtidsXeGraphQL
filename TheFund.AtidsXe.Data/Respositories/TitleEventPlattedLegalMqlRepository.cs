using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class TitleEventPlattedLegalMqlRepository : ITitleEventPlattedLegalMqlRepository
    {
        private readonly ATIDSXEContext _context;

        public TitleEventPlattedLegalMqlRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<TitleEventPlattedLegalMqlCompositeKey, TitleEventPlattedLegalMql>> GetTitleEventPlattedLegalMqlByIdAsync(IEnumerable<TitleEventPlattedLegalMqlCompositeKey> keys, CancellationToken token)
        {
            return (await _context.TitleEventPlattedLegalMql
                .Where(entity => keys.Select(p => p.PlatReferenceId).Contains(entity.PlatReferenceId) &&
                                 keys.Select(p => p.SubdivisionLevelId).Contains(entity.SubdivisionLevelId))
                .ToListAsync(token)).ToLookup(entity => new TitleEventPlattedLegalMqlCompositeKey(entity.PlatReferenceId, entity.SubdivisionLevelId));
        }

        public async Task<IDictionary<int, TitleEventPlattedLegalMql>> GetTitleEventPlattedLegalMqlByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.TitleEventPlattedLegalMql
                .Where(entity => keys.Contains(entity.PlatReferenceId))
                .ToDictionaryAsync(entity => entity.PlatReferenceId, token);
        }
    }
}
