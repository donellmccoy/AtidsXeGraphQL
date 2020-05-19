using ReactiveUI;
using System.Collections.Generic;
using System.Linq;

namespace TheFund.AtidsXe.Modules.Common.DataTransferObjects
{
    public partial class FileReference
    {
        public List<Search> PropertySearches
        {
            get
            {
                return Searches.Where(p => p.SearchTypeId == 1 || p.SearchTypeId == 3).ToList();
            }
        }

        public List<Search> NameSearches => Searches ?? Searches.Where(p => p.SearchTypeId == 2).ToList();

        public List<Search> PolicySearches => Searches ?? Searches.Where(p => p.SearchTypeId == 4).ToList();

        public bool IsTemporaryFileBool => IsTemporaryFile == 1;

        public bool HasFileReferenceNotes => FileReferenceNotes?.Any() ?? false;

        public bool HasSearches => Searches?.Any() ?? false;

        public bool HasPropertySearches => PropertySearches?.Any() ?? false;

        public bool HasPolicySearches => PolicySearches?.Any() ?? false;

        public bool HasNameSearches => NameSearches?.Any() ?? false;

        public bool HasChainOfTitles => ChainOfTitles?.Any() ?? false;

        public int ChainOfTitlesCount => ChainOfTitles?.Count ?? 0;

        public int PolicySearchesCount => PolicySearches?.Count ?? 0;

        public int PropertySearchesCount => PropertySearches?.Count ?? 0;

        public int NameSearchesCount => NameSearches?.Count ?? 0;

        public bool HasWorksheetItems => Worksheet?.WorksheetItems?.Any() ?? false;
         
        public bool HasPolicyWorksheetItems => Worksheet?.PolicyWorksheetItems?.Any() ?? false;

        public bool HasTitleSearchOrigination => TitleSearchOrigination != null;

        public string GetPropertyLegalDescription(ISearch search)
        {
            if(!HasPropertySearches)
            {
                return null;
            }

            //var searches =
            //        (from propertySearch in PropertySearches.Where(p => p.SearchTypeId == (int)SearchType.Acreage)
            //         let hasSections = propertySearch.UnplattedLegal.SectionBreakdownCodes.Any() &&
            //                                               search.UnplattedLegal.SectionBreakdownCodes.Any()
            //         where propertySearch.SearchTypeId == search.SearchTypeId &&
            //                                   hasSections ? (propertySearch.UnplattedLegal.SectionBreakdownCodes[0].Identity ==
            //                                                  search.UnplattedLegal.SectionBreakdownCodes[0].Identity) : true
            //         select propertySearch).ToList();


            //var d = from s in Searches
            //        from l in s.SubdivisionPlattedLegals
            //        where l.SearchId == searchId
            //        select l;

            return null;
        }

        public string GetPolicyLegalDescription(int searchId)
        {
            if (!HasPolicySearches)
            {
                return null;
            }

            //var d = from s in Searches
            //        from l in s.SubdivisionPlattedLegals
            //        where l.SearchId == searchId
            //        select l;

            return null;
        }

        public string GetNameLegalDescription(int searchId)
        {
            if (!HasNameSearches)
            {
                return null;
            }

            //var d = from s in Searches
            //        from l in s.SubdivisionPlattedLegals
            //        where l.SearchId == searchId
            //        select l;

            return null;
        }
    }
}
