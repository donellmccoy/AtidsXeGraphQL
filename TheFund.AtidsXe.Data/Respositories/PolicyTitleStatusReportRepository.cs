using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class PolicyTitleStatusReportRepository : IPolicyTitleStatusReportRepository
    {
        private readonly ATIDSXEContext _context;

        public PolicyTitleStatusReportRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, PolicyTitleStatusReport>> GetPolicyTitleStatusReportByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.PolicyTitleStatusReport
                .Where(entity => keys.Contains(entity.SearchId))
                .ToDictionaryAsync(entity => entity.SearchId, token);
        }
    }
}