using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IAcreageGovtLotLegalRepository
    {
        Task<IDictionary<int, AcreageGovtLotLegal>> GetAcreageGovtLotLegalByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, AcreageGovtLotLegal>> GetAcreageGovtLotLegalsIdAsync(IEnumerable<int> keys);
    }
}