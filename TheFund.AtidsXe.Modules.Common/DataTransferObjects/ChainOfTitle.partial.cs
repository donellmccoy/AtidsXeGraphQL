using System.Linq;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    public partial class ChainOfTitle
    {
        public bool HasChainOfTitleNotes => ChainOfTitleNotes.Any();

        public bool HasChainOfTitleItems => ChainOfTitleItems.Any();

        public bool HasChainOfTitleSearches => ChainOfTitleSearches.Any();

        public ChainOfTitleSearch GetChainOfTitleSearch(int chainOfTitleId)
        {
            return ChainOfTitleSearches.SingleOrDefault(p => p.ChainOfTitleId == chainOfTitleId);
        }
    }
}
