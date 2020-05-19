using DynamicData;
using JetBrains.Annotations;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Subjects;
using DynamicData.Binding;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Search.Models;

namespace TheFund.AtidsXe.Modules.Search.ViewModels
{
	public interface ISearchViewModel : IViewModel
	{
		IRecentSearchTerm SelectedRecentSearchTerm { get; set; }
		string SearchTerm { get; set; }
		ReadOnlyObservableCollection<IRecentSearchTerm> RecentSearchTerms { get; }
		int SearchResultsCount { get; }
        IEnumerable<IFileReferenceListItemViewModel> SearchListItemViewModels { get; }
		IFileReferenceListItemViewModel SelectedFileReferenceListItemViewModel { get; }
		IFileReference SelectedFileReference { get; set; }
		bool IsSearching { get; set; }
		ReactiveCommand<IFileReferenceListItemViewModel, IFileReference> LoadFileReferenceCommand { get; set; }
		SourceList<IFileReferenceListItemViewModel> SearchListItems { get; set; }
		bool HasSearchListItems { get; }
		IConnectableObservable<IEnumerable<FileReferenceListItemViewModel>> SearchTermConnectable { get; set; }
		ReadOnlyObservableCollection<IFileReferenceListItemViewModel> FavoriteListItemViewModels { get; }
        bool IsCompleted { get; set; }

        void HideBusyIndicator();
		void ShowBusyIndicator();
	}
}