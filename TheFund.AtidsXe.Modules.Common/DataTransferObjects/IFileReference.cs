using System;
using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    public interface IFileReference
    {
        int FileReferenceId { get; set; }
        string FileReferenceName { get; set; }
        int BranchLocationId { get; set; }
        int FileStatusId { get; set; }
        string WorkerId { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        int? DefaultGeographicLocaleId { get; set; }
        byte? IsTemporaryFile { get; set; }
        bool IsTemporaryFileBool { get; }
        BranchLocation BranchLocation { get; set; }
        FileStatus FileStatus { get; set; }
        GeographicLocale GeographicLocale { get; set; }
        TitleSearchOrigination TitleSearchOrigination { get; set; }
        Worksheet Worksheet { get; set; }
        List<ChainOfTitle> ChainOfTitles { get; set; }
        List<FileReferenceNotes> FileReferenceNotes { get; set; }
        List<Search> Searches { get; set; }
        List<Search> PropertySearches { get; }
        List<Search> NameSearches { get; }
        List<Search> PolicySearches { get; }
        bool HasPropertySearches { get; }
        bool HasPolicySearches { get; }
        bool HasNameSearches { get; }
        bool HasChainOfTitles { get; }
        bool HasSearches { get; }
        int ChainOfTitlesCount { get; }
        bool HasFileReferenceNotes { get; }
        bool HasWorksheetItems { get; }
        bool HasPolicyWorksheetItems { get; }
        bool HasTitleSearchOrigination { get; }
        int PolicySearchesCount { get; }
        int PropertySearchesCount { get; }
        int NameSearchesCount { get; }
        bool IsFavorite { get; set; }
    }
}