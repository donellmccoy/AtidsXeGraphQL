using JetBrains.Annotations;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Navigation.Services
{
    public interface INavigationService
    {
        void LoadFileReference(IFileReference fileReference);
        void UnloadFileReference(int fileReferenceId);
    }
}