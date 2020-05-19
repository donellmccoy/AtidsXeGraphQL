using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Factories
{
    public static class LoadProfileEventArgsFactory
    {
        public static IOpenProfileEventArgs Create(IEnumerable<IExaminationData> fileReferenceSearches)
        {
            return new OpenProfileEventArgs
            {
                FileReferenceSearches = fileReferenceSearches
            };
        }
    }
}