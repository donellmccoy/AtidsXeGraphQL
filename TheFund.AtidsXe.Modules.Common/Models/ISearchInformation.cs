using System;
using TheFund.AtidsXe.Modules.Common.Enumerations.Navigation;
using TheFund.AtidsXe.Modules.Common.Enumerations.Search;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface ISearchInformation
    {
        int SearchId { get; set; }
        int FileReferenceId { get; set; }
        string FileReferenceName { get; set; }
        SearchType SearchType { get; set; }
        NavigationGroupType NavigationGroupType{ get; set; }
        string Description { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
    }
}
