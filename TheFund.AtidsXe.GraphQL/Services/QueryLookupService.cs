using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using TheFund.AtidsXe.GraphQL.Models;
using TheFund.AtidsXe.Server.Services;

namespace TheFund.AtidsXe.GraphQL.Services
{
    public sealed class QueryLookupService : IQueryLookupService
    {
        private readonly IMemoryCache _memoryCache;

        public QueryLookupService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public string GetQueryById(string queryId)
        {
            if (string.IsNullOrWhiteSpace(queryId))
            {
                throw new ArgumentException("Query id cannot be null or empty string", nameof(queryId));
            }

            return _memoryCache.TryGetValue("Queries", out IEnumerable<GraphQLMapping> cacheEntry) ? 
                     cacheEntry.SingleOrDefault(p => p.Id == queryId).Query : 
                     null;
        }

        public GraphQLMapping GetQueryMappingById(string queryId)
        {
            if (string.IsNullOrWhiteSpace(queryId))
            {
                throw new ArgumentException("Query id cannot be null or empty string", nameof(queryId));
            }

            return _memoryCache.TryGetValue("Queries", out IEnumerable<GraphQLMapping> cacheEntry) ? 
                     cacheEntry.SingleOrDefault(p => p.Id == queryId) : 
                     null;
        }
    }
}
