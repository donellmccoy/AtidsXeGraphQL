using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class ParentSearchRepository : IParentSearchRepository
    {
        private readonly ATIDSXEContext _context;

        public ParentSearchRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, Search>> GetParentSearchByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.Search
                                 .Where(entity => keys.Contains(entity.ParentSearchId ?? 0))
                                 .ToDictionaryAsync(entity => entity.ParentSearchId ?? 0, token);
        }
    }
}