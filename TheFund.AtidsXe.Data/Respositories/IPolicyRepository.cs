using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;
namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IPolicyRepository
    {
        Task<IDictionary<int, Policy>> GetPoliciesByIdAsync(IEnumerable<int> keys, System.Threading.CancellationToken token);
        Task<ILookup<int, Policy>> GetPoliciesIdAsync(IEnumerable<int> keys);
    }
}