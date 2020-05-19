using JetBrains.Annotations;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar
{
    public interface IOutlookBarViewModel : IDisposable
    {
        DelegateCommand<IEnumerable<IOutlookBarItemViewModel>> CloseAllFileReferencesCommand { get; set; }
        int FilesOpenedCount { get; set; }
        IOutlookBarItemViewModel SelectedOutlookBarItemViewModel { get; set; }
        ObservableCollection<IOutlookBarItemViewModel> OutlookBarItemViewModels { get; set; }
        void LoadFileReference([NotNull] IFileReference fileReference);
        void UnloadFileReference([NotNull] IFileReference fileReference);
	}
}