using System.Collections.ObjectModel;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar
{
    public interface IOutlookBarItemViewModel
    {
        string Header { get; }
        string ImageSourcePath { get; set; }
        int FileReferenceId { get; }
        string FileReferenceName { get; }
        ObservableCollection<INavigationGroupTreeViewModel> NavigationGroupViewModels { get; }
        IFileReference FileReference { get; set; }
        IOutlookBarViewModel Parent { get; set; }
        void Build(IFileReference fileReference, IOutlookBarViewModel parent);
    }
}