﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IFileStatusRepository
    {
        Task<IDictionary<int, FileStatus>> GetFileStatusesByIdAsync(IEnumerable<int> keys, CancellationToken token);
    }
}