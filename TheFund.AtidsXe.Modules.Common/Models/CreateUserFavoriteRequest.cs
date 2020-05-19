using System;
using JetBrains.Annotations;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class CreateUserFavoriteRequest : ICreateUserFavoriteRequest
    {
        public int UserId { get; }
        public int[] FileReferenceIds { get; }

        public CreateUserFavoriteRequest(int userId, [NotNull] params int[] fileReferenceIds)
        {
            UserId = userId;
            FileReferenceIds = fileReferenceIds ?? throw new ArgumentNullException(nameof(fileReferenceIds));
        }
    }
}