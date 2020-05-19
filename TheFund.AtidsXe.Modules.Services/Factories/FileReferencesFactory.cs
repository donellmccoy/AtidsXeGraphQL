using System.Collections.Immutable;
using Newtonsoft.Json;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class FileReferencesFactory
    {
        public static ImmutableList<IFileReference> Create(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return ImmutableList<IFileReference>.Empty;
            }

            return ImmutableList.CreateRange<IFileReference>(JsonConvert.DeserializeObject<FileReferenceQuery>(json)?.FileReferences) ??
                   ImmutableList<IFileReference>.Empty;
        }
    }
}