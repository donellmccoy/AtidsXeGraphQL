using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class SearchRepository : ISearchRepository
    {
        private readonly ATIDSXEContext _context;

        public SearchRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, Search>> GetSearchesIdAsync(IEnumerable<int> keys)
        {
            return (await _context.Search.Where(entity => keys.Contains(entity.FileReferenceId)).ToListAsync()).ToLookup(entity => entity.FileReferenceId);
        }

        public async Task<IDictionary<int, Search>> GetSearchByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.Search.Where(entity => keys.Contains(entity.SearchId)).ToDictionaryAsync(entity => entity.SearchId, token);
        }
    }
}
