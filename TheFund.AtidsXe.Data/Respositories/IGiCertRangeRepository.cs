using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;
namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IGiCertRangeRepository
    {
        Task<IDictionary<int, CertificationRange>> GetGiCertRangeByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}