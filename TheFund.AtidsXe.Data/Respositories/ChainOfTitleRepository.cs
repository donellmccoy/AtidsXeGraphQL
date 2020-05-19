using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class ChainOfTitleRepository : IChainOfTitleRepository
    {
        private readonly ATIDSXEContext _context;

        public ChainOfTitleRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, ChainOfTitle>> GetChainOfTitleByFileReferenceIdAsync(IEnumerable<int> keys)
        {
            return (await _context.ChainOfTitle
                                  .TagWith("Chain of title key mappings")
                                  .Where(entity => keys.Contains(entity.FileReferenceId))
                                  .ToListAsync()
                                  .ConfigureAwait(false)).ToLookup(entity => entity.FileReferenceId);
        }
    }
}
