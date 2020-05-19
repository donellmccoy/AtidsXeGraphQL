using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class PolicyPlattedLegalMqlRepository : IPolicyPlattedLegalMqlRepository
    {
        private readonly ATIDSXEContext _context;

        public PolicyPlattedLegalMqlRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<PolicyPlattedLegalMqlCompositeKey, PolicyPlattedLegalMql>> GetPolicyPlattedLegalMqlByIdAsync(IEnumerable<PolicyPlattedLegalMqlCompositeKey> keys, CancellationToken token)
        {
            return (await _context.PolicyPlattedLegalMql
                .Where(entity => keys.Select(p => p.PlatReferenceId).Contains(entity.PlatReferenceId) &&
                                 keys.Select(p => p.SubdivisionLevelId).Contains(entity.SubdivisionLevelId))
                .ToListAsync(token)).ToLookup(entity => new PolicyPlattedLegalMqlCompositeKey(entity.PlatReferenceId, entity.SubdivisionLevelId));
        }

        public async Task<IDictionary<int, PolicyPlattedLegalMql>> GetPolicyPlattedLegalMqlByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.PolicyPlattedLegalMql
                .Where(entity => keys.Contains(entity.PlatReferenceId))
                .ToDictionaryAsync(entity => entity.PlatReferenceId, token);
        }

        public async Task<IDictionary<PolicyPlattedLegalMqlCompositeKey, PolicyPlattedLegalMql>> GetPlattedLegalByKeysAsync(IEnumerable<PolicyPlattedLegalMqlCompositeKey> keys, CancellationToken token)
        {
            return await _context.PolicyPlattedLegalMql
                .Where(entity => keys.Select(p => p.PlatReferenceId).Contains(entity.PlatReferenceId) &&
                                 keys.Select(p => p.SubdivisionLevelId).Contains(entity.SubdivisionLevelId))
                .ToDictionaryAsync(entity => new PolicyPlattedLegalMqlCompositeKey(entity.PlatReferenceId, entity.SubdivisionLevelId), token);
        }
    }
}
