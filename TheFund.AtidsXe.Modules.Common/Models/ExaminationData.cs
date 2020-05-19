using System;
using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Events.Search;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public class ExaminationData : IExaminationData
    {
        public ExaminationData()
        {
            SearchInformation = new List<ISearchInformation>();
        }

        public int FileReferenceId { get; set; }

        public string FileReferenceName { get; set; }

        public string FileStatus { get; set; }

        public DateTime LastUpdated { get; set; }

        public NavigationLoadType NavigationLoadType { get; set; }

        public IEnumerable<ISearchInformation> SearchInformation { get; set; }
    }
}