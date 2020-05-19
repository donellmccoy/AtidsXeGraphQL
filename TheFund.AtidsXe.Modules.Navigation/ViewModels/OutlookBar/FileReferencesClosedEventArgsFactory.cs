using System;
using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar
{
    internal static class FileReferencesClosedEventArgsFactory
    {
        internal static IFileReferencesClosedEventArgs Create(IEnumerable<int> enumerable)
        {
            return new FileReferencesClosedEventArgs { FileReferenceIds = enumerable };
        }
    }
}