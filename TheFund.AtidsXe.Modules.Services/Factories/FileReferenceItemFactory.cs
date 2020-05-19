using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Ensure;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class FileReferenceItemFactory
    {
        public static IEnumerable<IFileReferenceItem> CreateItems(string json)
        { 
            json.EnsureNotNullOrWhitespace();
            var fileReferences = JsonConvert.DeserializeObject<FileReferenceQuery>(json)?.FileReferences;
            return fileReferences?.Select(p => new FileReferenceItem(p)) ?? Enumerable.Empty<IFileReferenceItem>();
        }
    }
}