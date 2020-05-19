using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class FileReferenceNotesRepository : IFileReferenceNotesRepository
    {
        private readonly ATIDSXEContext _context;

        public FileReferenceNotesRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, FileReferenceNotes>> GetFileReferenceNotesByKeysAsync(IEnumerable<int> keys)
        {
            return (await _context.FileReferenceNotes
                                  .Where(entity => keys.Contains(entity.FileReferenceId)).ToListAsync())
                                  .ToLookup(entity => entity.FileReferenceId);
        }

        public async Task<IDictionary<int, FileReferenceNotes>> GetFileReferenceNoteByKeysAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.FileReferenceNotes
                                 .Where(entity => keys.Contains(entity.FileReferenceId))
                                 .ToDictionaryAsync(entity => entity.FileReferenceId, token);
        }
    }
}
