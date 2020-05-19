using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IChainOfTitleRepository
    {
        Task<ILookup<int, ChainOfTitle>> GetChainOfTitleByFileReferenceIdAsync(IEnumerable<int> keys);
    }
}
