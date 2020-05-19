using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class PlattedLegalRepository : IPlattedLegalRepository
    {
        private readonly ATIDSXEContext _context;

        public PlattedLegalRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, PlattedLegal>> GetPlattedLegalsByIdAsync(IEnumerable<int> keys)
        {
            return (await _context.PlattedLegal.Where(entity => keys.Contains(entity.PlatReferenceId)).ToListAsync()).ToLookup(entity => entity.PlatReferenceId);
        }

        public async Task<IDictionary<int, PlattedLegal>> GetPlattedLegalByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.PlattedLegal
                                 .Where(entity => keys.Contains(entity.SubdivisionLevelId))
                                 .ToDictionaryAsync(entity => entity.SubdivisionLevelId, token);
        }

        public async Task<IDictionary<PlattedLegalCompositeKey, PlattedLegal>> GetPlattedLegalByKeysAsync(IEnumerable<PlattedLegalCompositeKey> keys, CancellationToken token)
        {
            return await _context.PlattedLegal
                                 .Where(entity => keys.Select(compositeKey => compositeKey.PlatReferenceId).Contains(entity.PlatReferenceId) && 
                                                  keys.Select(compositeKey => compositeKey.SubdivisionLevelId).Contains(entity.SubdivisionLevelId))
                                 .ToDictionaryAsync(entity => new PlattedLegalCompositeKey(entity.PlatReferenceId, entity.SubdivisionLevelId), token);
        }
    }
}
