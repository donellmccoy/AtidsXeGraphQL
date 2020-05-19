using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Events.EventArguments
{
    public class FileReferencesClosedEventArgs : IFileReferencesClosedEventArgs
    {
        public IEnumerable<int> FileReferenceIds { get; set; }
    }
}