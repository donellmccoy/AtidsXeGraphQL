using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class GeographicLocaleRepository : IGeographicLocaleRepository
    {
        private readonly ATIDSXEContext _context;

        public GeographicLocaleRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, GeographicLocale>> GetGeographicLocaleByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            var results = await _context.GeographicLocale
                                 .Where(entity => keys.Contains(entity.GeographicLocaleId))
                                 .ToDictionaryAsync(entity => entity.GeographicLocaleId, token);
            return results;
        }
    }
}
