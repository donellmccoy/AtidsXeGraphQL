using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ITitleEventPlattedLegalMqlRepository
    {
        Task<ILookup<CompositeKeys.TitleEventPlattedLegalMqlCompositeKey, TitleEventPlattedLegalMql>> GetTitleEventPlattedLegalMqlByIdAsync(IEnumerable<CompositeKeys.TitleEventPlattedLegalMqlCompositeKey> keys, System.Threading.CancellationToken token);
        Task<IDictionary<int, TitleEventPlattedLegalMql>> GetTitleEventPlattedLegalMqlByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}