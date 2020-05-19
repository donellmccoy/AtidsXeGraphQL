using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class GetUserFavoritesResponse : IGetUserFavoritesResponse
    {
        public int UserId { get; }
        public IEnumerable<IFileReference> FileReferences { get; }

        public GetUserFavoritesResponse(int userId, IEnumerable<IFileReference> fileReferences)
        {
            UserId = userId;
            FileReferences = fileReferences;
        }
    }
}