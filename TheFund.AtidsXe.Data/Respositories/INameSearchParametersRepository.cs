﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;
namespace TheFund.AtidsXe.Data.Respositories
{
    public interface INameSearchParametersRepository
    {
        Task<IDictionary<int, NameSearchParameters>> GetNameSearchParametersByKeysAsync(IEnumerable<int> keys, CancellationToken token);
    }
}