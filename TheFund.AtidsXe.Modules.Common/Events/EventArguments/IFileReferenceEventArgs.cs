using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Events.EventArguments
{
    public interface IOpenFileReferenceEventArgs
    {
        int FileReferenceId { get; set; }
    }
}