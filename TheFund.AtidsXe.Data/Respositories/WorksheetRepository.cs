using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class WorksheetRepository : IWorksheetRepository
    {
        private readonly ATIDSXEContext _context;

        public WorksheetRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, Worksheet>> GetWorksheetsByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.Worksheet.Where(entity => keys.Contains(entity.FileReferenceId)).ToDictionaryAsync(entity => entity.FileReferenceId, token);
        }

        public async Task<ILookup<int, Worksheet>> GetWorksheetsIdAsync(IEnumerable<int> keys)
        {
            return (await _context.Worksheet.Where(entity => keys.Contains(entity.FileReferenceId)).ToListAsync())
                                            .ToLookup(entity => entity.FileReferenceId);
        }
    }
}
