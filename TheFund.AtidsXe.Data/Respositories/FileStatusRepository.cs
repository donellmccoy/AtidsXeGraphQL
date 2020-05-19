using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class FileStatusRepository : IFileStatusRepository
    {
        private readonly ATIDSXEContext _context;

        public FileStatusRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, FileStatus>> GetFileStatusesByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.FileStatus
                                 .Where(entity => keys.Contains(entity.FileStatusId))
                                 .ToDictionaryAsync(entity => entity.FileStatusId, token);
        }
    }
}
