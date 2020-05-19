using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.Events.EventArguments
{
    public interface IFileReferencesClosedEventArgs
    {
        IEnumerable<int> FileReferenceIds { get; set; }
    }
}