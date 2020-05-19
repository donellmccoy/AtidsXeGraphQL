using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;

namespace TheFund.AtidsXe.Modules.Common.Factories
{
    public static class FileReferencesClosedEventArgsFactory
    {
        public static IFileReferencesClosedEventArgs Create(IEnumerable<int> fileReferenceIds)
        {
            return new FileReferencesClosedEventArgs
            {
                FileReferenceIds = fileReferenceIds
            };
        }
    }
}