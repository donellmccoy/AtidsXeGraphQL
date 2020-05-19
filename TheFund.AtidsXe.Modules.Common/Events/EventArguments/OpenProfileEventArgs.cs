using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Events.Search;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Events.EventArguments
{
    public class OpenProfileEventArgs : IOpenProfileEventArgs
    {
        public IEnumerable<IExaminationData> FileReferenceSearches { get; set; }
    }
}