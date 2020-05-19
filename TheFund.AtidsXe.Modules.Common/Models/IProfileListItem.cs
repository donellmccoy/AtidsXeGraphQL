using System;
using Telerik.Windows.Data;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface IProfileListItem
    {
        int UserId { get; set; }
        int ProfileId { get; set; }
        string ProfileName { get; set; }
        string Description { get; set; }
        bool IsLoaded { get; set; }
        RadObservableCollection<IFileReference> FileReferences { get; set; }
        string Loaded { get; }
        DateTime CreatedDate { get; set; }
        int CreatedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int ModifiedBy { get; set; }
    }
}