using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IWorksheetRepository
    {
        Task<IDictionary<int, Worksheet>> GetWorksheetsByIdAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, Worksheet>> GetWorksheetsIdAsync(IEnumerable<int> keys);
    }
}