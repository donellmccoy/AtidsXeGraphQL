using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IChainOfTitleSearchRepository
    {
        Task<ILookup<int, ChainOfTitleSearch>> GetChainOfTitleSearchesByChainOfTitleIdAsync(IEnumerable<int> keys);
    }
}