using System.Threading;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class FileReferenceRequestFactory
    {
        public static IFileReferenceRequest Create(int fileReferenceId, CancellationToken token)
        {
            return new FileReferenceRequest(fileReferenceId);
        }
    }
}