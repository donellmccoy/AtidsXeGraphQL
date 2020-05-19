using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class PolicyWorksheetItemRepository : IPolicyWorksheetItemRepository
    {
        private readonly ATIDSXEContext _context;

        public PolicyWorksheetItemRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, PolicyWorksheetItem>> GetPolicyWorksheetItemsByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.PolicyWorksheetItem.Where(entity => keys.Contains(entity.WorksheetId)).ToDictionaryAsync(entity => entity.WorksheetId, token);
        }

        public async Task<ILookup<int, PolicyWorksheetItem>> GetPolicyWorksheetItemsIdAsync(IEnumerable<int> keys)
        {
            return (await _context.PolicyWorksheetItem.Where(entity => keys.Contains(entity.WorksheetId)).ToListAsync()).ToLookup(entity => entity.WorksheetId);
        }
    }
}
