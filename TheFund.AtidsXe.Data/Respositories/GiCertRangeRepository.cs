using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class GiCertRangeRepository : IGiCertRangeRepository
    {
        private readonly ATIDSXEContext _context;

        public GiCertRangeRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, CertificationRange>> GetGiCertRangeByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.CertificationRange
                .Where(entity => keys.Contains(entity.CertificationRangeId))
                .ToDictionaryAsync(entity => entity.CertificationRangeId, token);
        }
    }
}