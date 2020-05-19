using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class SearchTypeRepository : ISearchTypeRepository
    {
        private readonly ATIDSXEContext _context;

        public SearchTypeRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, SearchType>> GetSearchTypeByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.SearchType
                                 .Where(entity => keys.Contains(entity.SearchTypeId))
                                 .ToDictionaryAsync(entity => entity.SearchTypeId, token);
        }

        public async Task<ILookup<int, Search>> GetSearchesIdAsync(IEnumerable<int> keys)
        {
            return (await _context.Search.Where(entity => keys.Contains(entity.SearchId)).ToListAsync()).ToLookup(entity => entity.SearchId);
        }
    }
}
