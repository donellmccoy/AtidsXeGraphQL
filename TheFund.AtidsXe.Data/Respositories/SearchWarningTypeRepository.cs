using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class SearchWarningTypeRepository : ISearchWarningTypeRepository
    {
        private readonly ATIDSXEContext _context;

        public SearchWarningTypeRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, SearchWarningType>> GetSearchWarningTypeByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.SearchWarningType
                                 .Where(entity => keys.Contains(entity.SearchWarningTypeId))
                                 .ToDictionaryAsync(entity => entity.SearchWarningTypeId, token);
        }

        public async Task<ILookup<int, SearchWarningType>> GetSearchWarningTypesIdAsync(IEnumerable<int> keys)
        {
            return (await _context.SearchWarningType.Where(entity => keys.Contains(entity.SearchWarningTypeId))
                .ToListAsync()).ToLookup(entity => entity.SearchWarningTypeId);
        }
    }
}
