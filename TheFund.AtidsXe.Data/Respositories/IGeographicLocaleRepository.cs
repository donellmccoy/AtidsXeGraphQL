using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IGeographicLocaleRepository
    {
        Task<IDictionary<int, GeographicLocale>> GetGeographicLocaleByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}