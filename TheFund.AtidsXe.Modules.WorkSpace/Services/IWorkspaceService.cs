using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.WorkSpace.Services
{
    public interface IWorkspaceService
    {
        Task ShowPropertySearchesView(IFileReference fileReference);
        Task ShowPropertySearchLegalView(IFileReference fileReference);
        Task ShowPropertySearchView((IFileReference fileReference, int searchId) args);
        Task ShowChainOfTitlesView(IFileReference fileReference);
        Task ShowChainOfTitleView((IFileReference fileReference, int chainOfTitleId, int searchId) args);
        Task ShowWorksheetView(IFileReference fileReference);
        int GetWorkspaceSelectedIndex();
    }
}