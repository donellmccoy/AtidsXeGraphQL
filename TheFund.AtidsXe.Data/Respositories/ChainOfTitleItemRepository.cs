using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class ChainOfTitleItemRepository : IChainOfTitleItemRepository
    {
        private readonly ATIDSXEContext _context;

        public ChainOfTitleItemRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, ChainOfTitleItem>> GetChainOfTitleItemsByChainOfTitleIdAsync(IEnumerable<int> keys)
        {
            return (await _context.ChainOfTitleItem.Where(entity => keys.Contains(entity.ChainOfTitleId)).ToListAsync()).ToLookup(entity => entity.ChainOfTitleId);
        }
    }
}
