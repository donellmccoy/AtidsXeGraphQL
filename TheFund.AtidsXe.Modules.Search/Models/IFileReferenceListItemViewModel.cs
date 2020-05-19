using Prism.Commands;
using System;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Search.ViewModels;

namespace TheFund.AtidsXe.Modules.Search.Models
{
	public interface IFileReferenceListItemViewModel
	{
		string ImageUrl { get; set; }
		int FileReferenceId { get; set; }
		string FileReferenceName { get; set; }
		string WorkerId { get; set; }
		DateTime CreatedDate { get; set; }
		DateTime UpdateDate { get; set; }
		bool IsTemporaryFile { get; set; }
		FileStatus FileStatus { get; set; }
		BranchLocation BranchLocation { get; set; }
		bool IsInUse { get; set; }
		string CreatedDateFormatted { get; set; }
		bool HasChainOfTitles { get; set; }
		int ChainOfTitlesCount { get; set; }
		string HasChainOfTitlesText { get; }
		int PolicySearchesCount { get; set; }
		int PropertySearchesCount { get; set; }
		int NameSearchesCount { get; set; }
		bool HasLoaded { get; set; }
		ISearchViewModel Parent { get; set; }
		DelegateCommand<bool?> AddRemoveFromWorkspaceCommand { get; set; }
		bool IsInWorkspace { get; set; }
		bool AllowFileHistory { get; set; }
		bool IsDirty { get; set; }
		DelegateCommand ShowFileHistoryCommand { get; set; }
		DelegateCommand FindRelatedFilesCommand { get; set; }
		DelegateCommand SaveAllChangesCommand { get; set; }
		DelegateCommand UndoAllChangesCommand { get; set; }
		IFileReference FileReference { get; set; }
		bool IsOpened { get; }
        bool IsFavorite { get; }
        string ToString();
	}
}