using System.Linq;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    public partial class Search
    {
        public bool LrsSearchBool => LrsSearch == 1;

        public bool InclMortgageeShortFormBool => InclMortgageeShortForm == 1;

        public bool IsHiddenBool => Hidden == 1;

        public bool HasTitleEventSearches => TitleEventSearches?.Any() ?? false;

        public bool HasSubdivisionPlattedLegals => SubdivisionPlattedLegals?.Any() ?? false;
    }
}
