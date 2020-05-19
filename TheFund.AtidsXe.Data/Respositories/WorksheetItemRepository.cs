using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class WorksheetItemRepository : IWorksheetItemRepository
    {
        private readonly ATIDSXEContext _context;

        public WorksheetItemRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, WorksheetItem>> GetWorksheetItemsByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.WorksheetItem.Where(entity => keys.Contains(entity.WorksheetId)).ToDictionaryAsync(entity => entity.WorksheetId, token);
        }

        public async Task<ILookup<int, WorksheetItem>> GetWorksheetItemsIdAsync(IEnumerable<int> keys)
        {
            return (await _context.WorksheetItem.Where(entity => keys.Contains(entity.WorksheetId)).ToListAsync()).ToLookup(entity => entity.WorksheetId);
        }
    }
}
