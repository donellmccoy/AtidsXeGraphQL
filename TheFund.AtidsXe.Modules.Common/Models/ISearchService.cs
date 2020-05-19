using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using JetBrains.Annotations;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface ISearchService
    {
        SourceList<string> SearchResults { get; set; }
        IObservable<int> Count { get; }

        Task<IFileReferenceResponse> GetFileReferenceAsync([NotNull] IFileReferenceRequest request, CancellationToken token = default);
        IObservable<IEnumerable<IFileReference>> SearchFileReferences(string searchTerm, CancellationToken token);
        Task<ImmutableList<IFileReference>> SearchFileReferencesAsync([NotNull] string searchTerm, CancellationToken token = default);
    }
}