using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class PolicyRepository : IPolicyRepository
    {
        private readonly ATIDSXEContext _context;

        public PolicyRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, Policy>> GetPoliciesByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.Policy.Where(entity => keys.Contains(entity.PolicyId)).ToDictionaryAsync(entity => entity.PolicyId, token);
        }

        public async Task<ILookup<int, Policy>> GetPoliciesIdAsync(IEnumerable<int> keys)
        {
            return (await _context.Policy.Where(entity => keys.Contains(entity.PolicyId)).ToListAsync()).ToLookup(entity => entity.PolicyId);
        }
    }
}
