using Newtonsoft.Json;
using System;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class FileReferenceFactory
    {
        public static IFileReference Create(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentNullException(nameof(json), "Json string cannot be null or empty.");
            }

            return JsonConvert.DeserializeObject<FileReferenceQuery>(json)?.FileReference;
        }
    }
}