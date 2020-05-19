using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class SearchStatusRepository : ISearchStatusRepository
    {
        private readonly ATIDSXEContext _context;

        public SearchStatusRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, SearchStatus>> GetSearchStatusByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.SearchStatus
                .Where(entity => keys.Contains(entity.SearchStatusId))
                .ToDictionaryAsync(entity => entity.SearchStatusId, token);
        }
    }
}