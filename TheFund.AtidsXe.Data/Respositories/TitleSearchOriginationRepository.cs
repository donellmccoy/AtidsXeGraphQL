using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class TitleSearchOriginationRepository : ITitleSearchOriginationRepository
    {
        private readonly ATIDSXEContext _context;

        public TitleSearchOriginationRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, TitleSearchOrigination>> GetTitleSearchOriginationsByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.TitleSearchOrigination.Where(entity => keys.Contains(entity.FileReferenceId)).ToDictionaryAsync(entity => entity.FileReferenceId, token);
        }
    }
}
