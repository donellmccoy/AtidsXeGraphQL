using System.Collections.Generic;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    public interface IChainOfTitle
    {
        ChainOfTitleSearch GetChainOfTitleSearch(int chainOfTitleId);
        int ChainOfTitleId { get; set; }
        int FileReferenceId { get; set; }
        List<ChainOfTitleItem> ChainOfTitleItems { get; set; }
        List<ChainOfTitleNotes> ChainOfTitleNotes { get; set; }
        List<ChainOfTitleSearch> ChainOfTitleSearches { get; set; }
    }
}