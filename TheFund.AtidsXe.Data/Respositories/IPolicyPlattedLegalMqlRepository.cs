using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.CompositeKeys;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IPolicyPlattedLegalMqlRepository
    {
        Task<IDictionary<PolicyPlattedLegalMqlCompositeKey, PolicyPlattedLegalMql>> GetPlattedLegalByKeysAsync(IEnumerable<PolicyPlattedLegalMqlCompositeKey> keys, CancellationToken token);
        Task<ILookup<PolicyPlattedLegalMqlCompositeKey, PolicyPlattedLegalMql>> GetPolicyPlattedLegalMqlByIdAsync(IEnumerable<PolicyPlattedLegalMqlCompositeKey> keys, CancellationToken token);
        Task<IDictionary<int, PolicyPlattedLegalMql>> GetPolicyPlattedLegalMqlByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}