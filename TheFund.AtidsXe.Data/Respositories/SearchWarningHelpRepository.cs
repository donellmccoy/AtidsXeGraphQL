using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class SearchWarningHelpRepository : ISearchWarningHelpRepository
    {
        private readonly ATIDSXEContext _context;

        public SearchWarningHelpRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, SearchWarningHelp>> GetSearchWarningHelpByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.SearchWarningHelp
                                 .Where(entity => keys.Contains(entity.SearchWarningTypeId))
                                 .ToDictionaryAsync(entity => entity.SearchWarningTypeId, token);
        }
    }
}
