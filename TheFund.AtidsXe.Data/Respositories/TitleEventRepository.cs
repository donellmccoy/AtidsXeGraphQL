using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class TitleEventRepository : ITitleEventRepository
    {
        private readonly ATIDSXEContext _context;

        public TitleEventRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, TitleEvent>> GetTitleEventsByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.TitleEvent.Where(entity => keys.Contains(entity.TitleEventId)).ToDictionaryAsync(entity => entity.TitleEventId, token);
        }
    }
}
