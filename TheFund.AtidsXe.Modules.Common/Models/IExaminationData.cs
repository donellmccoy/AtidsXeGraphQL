using System;
using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Events.Search;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface IExaminationData
    {
        int FileReferenceId { get; set; }
        string FileReferenceName { get; set; }
        IEnumerable<ISearchInformation> SearchInformation { get; set; }
        string FileStatus { get; set; }
        DateTime LastUpdated { get; set; }
        NavigationLoadType NavigationLoadType { get; set; }
    }
}
