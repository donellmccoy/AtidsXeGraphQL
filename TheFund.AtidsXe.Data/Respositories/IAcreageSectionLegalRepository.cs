using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IAcreageSectionLegalRepository
    {
        Task<IDictionary<int, AcreageSectionLegal>> GetAcreageSectionLegalsByIdAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, AcreageSectionLegal>> GetAcreageSectionLegalsBySearchIdAsync(IEnumerable<int> keys);
    }
}