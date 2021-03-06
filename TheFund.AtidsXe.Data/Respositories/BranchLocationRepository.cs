﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class BranchLocationRepository : IBranchLocationRepository
    {
        private readonly ATIDSXEContext _context;

        public BranchLocationRepository(ATIDSXEContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<int, BranchLocation>> GetBranchLocationsByIdAsync(IEnumerable<int> keys, CancellationToken token)
        {
            return await _context.BranchLocation
                                 .Where(entity => keys.Contains(entity.BranchLocationId))
                                 .ToDictionaryAsync(entity => entity.BranchLocationId, token);
        }
    }
}
