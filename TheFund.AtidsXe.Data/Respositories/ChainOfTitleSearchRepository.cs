using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class ChainOfTitleSearchRepository : IChainOfTitleSearchRepository
    {
        private readonly ATIDSXEContext _context;

        public ChainOfTitleSearchRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, ChainOfTitleSearch>> GetChainOfTitleSearchesByChainOfTitleIdAsync(IEnumerable<int> keys)
        {
            return (await _context.ChainOfTitleSearch.Where(entity => keys.Contains(entity.ChainOfTitleId)).ToListAsync()).ToLookup(entity => entity.ChainOfTitleId);
        }
    }
}
