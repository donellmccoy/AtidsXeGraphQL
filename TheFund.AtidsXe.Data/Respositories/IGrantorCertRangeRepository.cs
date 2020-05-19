using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;
namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IGrantorCertRangeRepository
    {
        Task<IDictionary<int, CertificationRange>> GetGrantorCertRangeByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}