using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFund.AtidsXe.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Services.Aggregation
{
    internal class AggregationService
    {
        public string GetLegalDescription(IFileReference fileReference, int searchId)
        {
            var d = from s in fileReference.Searches
                    from l in s.SubdivisionPlattedLegals
                    where l.SearchId == searchId
                    select l;

            return null;
        }
    }
}
