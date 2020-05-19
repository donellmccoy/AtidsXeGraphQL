using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class ChainOfTitleCategoryRepository : IChainOfTitleCategoryRepository
    {
        private readonly ATIDSXEContext _context;

        public ChainOfTitleCategoryRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, ChainOfTitleCategory>> GetChainOfTitleCategoriesByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.ChainOfTitleCategory
                                 .Where(entity => keys.Contains(entity.ChainOfTitleCategoryId))
                                 .ToDictionaryAsync(entity => entity.ChainOfTitleCategoryId, token);
        }
    }
}
