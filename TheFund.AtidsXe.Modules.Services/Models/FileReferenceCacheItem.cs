using Ensure;
using System;
using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Services.Models
{
    public sealed class FileReferenceCacheItem : IFileReferenceCacheItem, IEquatable<IFileReferenceCacheItem>
    {
        public FileReferenceCacheItem(int fileReferenceId, string fileReferenceJson)
        {
            fileReferenceJson.EnsureNotNullOrWhitespace();

            FileReferenceId = fileReferenceId;
            ReferenceJson = fileReferenceJson;
            CreatedDate = DateTime.Now;
        }

        public int FileReferenceId { get; }

        public string ReferenceJson { get; }

        public DateTime CreatedDate { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as FileReferenceCacheItem);
        }

        public bool Equals(IFileReferenceCacheItem other)
        {
            return other != null && FileReferenceId == other.FileReferenceId;
        }

        public override int GetHashCode()
        {
            return -622241763 + FileReferenceId.GetHashCode();
        }

        public static bool operator == (IFileReferenceCacheItem left, FileReferenceCacheItem right)
        {
            return EqualityComparer<IFileReferenceCacheItem>.Default.Equals(left, right);
        }

        public static bool operator != (IFileReferenceCacheItem left, FileReferenceCacheItem right)
        {
            return !(left == right);
        }
    }
}