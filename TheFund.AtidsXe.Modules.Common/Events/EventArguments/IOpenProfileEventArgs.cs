using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Events.EventArguments
{
    public interface IOpenProfileEventArgs
    {
        IEnumerable<IExaminationData> FileReferenceSearches { get; set; }
    }
}