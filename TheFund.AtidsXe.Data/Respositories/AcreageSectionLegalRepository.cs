using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class AcreageSectionLegalRepository : IAcreageSectionLegalRepository
    {
        private readonly ATIDSXEContext _context;

        public AcreageSectionLegalRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, AcreageSectionLegal>> GetAcreageSectionLegalsBySearchIdAsync(IEnumerable<int> keys)
        {
            return (await _context.AcreageSectionLegal.Where(entity => keys.Contains(entity.SearchId)).ToListAsync()).ToLookup(entity => entity.SearchId);
        }

        public async Task<IDictionary<int, AcreageSectionLegal>> GetAcreageSectionLegalsByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.AcreageSectionLegal
                                 .Where(entity => keys.Contains(entity.SearchId))
                                 .ToDictionaryAsync(entity => entity.SearchId, token);
        }
    }
}
