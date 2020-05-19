using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class ChainOfTitleNoteRepository : IChainOfTitleNoteRepository
    {
        private readonly ATIDSXEContext _context;

        public ChainOfTitleNoteRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, ChainOfTitleNotes>> GetChainOfTitleNotesByChainOfTitleIdAsync(IEnumerable<int> keys)
        {
            return (await _context.ChainOfTitleNotes.Where(entity => keys.Contains(entity.ChainOfTitleId)).ToListAsync()).ToLookup(entity => entity.ChainOfTitleId);
        }
    }
}
