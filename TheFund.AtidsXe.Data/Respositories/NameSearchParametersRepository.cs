using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class NameSearchParametersRepository : INameSearchParametersRepository
    {
        private readonly ATIDSXEContext _context;

        public NameSearchParametersRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, NameSearchParameters>> GetNameSearchParametersByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.NameSearchParameters
                .Where(entity => keys.Contains(entity.SearchId))
                .ToDictionaryAsync(entity => entity.SearchId, token);
        }
    }
}