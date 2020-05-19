using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;
namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IPolicyTitleStatusReportRepository
    {
        Task<IDictionary<int, PolicyTitleStatusReport>> GetPolicyTitleStatusReportByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}