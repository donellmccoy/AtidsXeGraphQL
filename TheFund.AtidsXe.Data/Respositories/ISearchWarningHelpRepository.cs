using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface ISearchWarningHelpRepository
    {
        Task<IDictionary<int, SearchWarningHelp>> GetSearchWarningHelpByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}