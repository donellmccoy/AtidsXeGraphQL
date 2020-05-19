using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IGeographicCertRangeRepository
    {
        Task<IDictionary<int, CertificationRange>> GetGeographicCertRangeByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}