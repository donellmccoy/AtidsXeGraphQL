using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IFileReferenceNotesRepository
    {
        Task<IDictionary<int, FileReferenceNotes>> GetFileReferenceNoteByKeysAsync(IEnumerable<int> keys, CancellationToken token);
        Task<ILookup<int, FileReferenceNotes>> GetFileReferenceNotesByKeysAsync(IEnumerable<int> keys);
    }
}