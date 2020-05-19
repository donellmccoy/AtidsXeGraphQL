using System;
using JetBrains.Annotations;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class DeleteUserFavoritesRequest : IDeleteUserFavoritesRequest
    {
        public int UserId { get; }
        public int[] FileReferences { get; }
        public string CacheRegion { get; }
        public string CacheKey { get; }

        public DeleteUserFavoritesRequest(int userId, [NotNull] params int[] fileReferenceIds)
        {
            UserId = userId;
            FileReferences = fileReferenceIds ?? throw new ArgumentNullException(nameof(fileReferenceIds));
            CacheKey = $"{userId}";
            CacheRegion = "UserFavorites";
        }
    }
}