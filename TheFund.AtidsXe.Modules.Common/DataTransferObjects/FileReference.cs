using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class FileReference : IFileReference
    {
        public FileReference()
        {
            ChainOfTitles = new List<ChainOfTitle>();
            FileReferenceNotes = new List<FileReferenceNotes>();
            Searches = new List<Search>();
        }
        [JsonProperty]
        public int FileReferenceId { get; set; }
        [JsonProperty]
        public string FileReferenceName { get; set; }
        [JsonProperty]
        public int BranchLocationId { get; set; }
        [JsonProperty]
        public int FileStatusId { get; set; }
        [JsonProperty]
        public string WorkerId { get; set; }
        [JsonProperty]
        public DateTime CreateDate { get; set; }
        [JsonProperty]
        public DateTime UpdateDate { get; set; }
        [JsonProperty]
        public int? DefaultGeographicLocaleId { get; set; }
        [JsonProperty]
        public byte? IsTemporaryFile { get; set; }
        [JsonProperty]
        public BranchLocation BranchLocation { get; set; }
        [JsonProperty]
        public FileStatus FileStatus { get; set; }
        [JsonProperty]
        public GeographicLocale GeographicLocale { get; set; }
        [JsonProperty]
        public TitleSearchOrigination TitleSearchOrigination { get; set; }
        [JsonProperty]
        public Worksheet Worksheet { get; set; }
        [JsonProperty]
        public List<ChainOfTitle> ChainOfTitles { get; set; }
        [JsonProperty]
        public List<FileReferenceNotes> FileReferenceNotes { get; set; }
        [JsonProperty]
        public List<Search> Searches { get; set; }

        public bool IsFavorite { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return !(obj is FileReference fileReference) ? false : Equals(fileReference);
        }

        protected bool Equals(FileReference other)
        {
            return other == null ? false : FileReferenceId == other.FileReferenceId;
        }

        public override int GetHashCode()
        {
            return FileReferenceId.GetHashCode();
        }

        public override string ToString()
        {
            return $"FileReferenceId: {FileReferenceId, -10}FileReferenceName: {FileReferenceName}";
        }
    }
}
