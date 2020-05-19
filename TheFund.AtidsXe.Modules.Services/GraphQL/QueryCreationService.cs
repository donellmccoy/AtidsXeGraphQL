using Carlabs.Getit;
using Ensure;
using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.Services.GraphQL
{
    [Export(typeof(IQueryCreationService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class QueryCreationService : IQueryCreationService
    {
        private const string END_POINT_ADDRESS = "http://localhost:5001/api/graphql";
        private readonly Getit _getit;

        public QueryCreationService()
        {
            _getit = new Getit(new Config(END_POINT_ADDRESS));
        }

        public string CreateFileReferencesNameQuery(string fileReferenceName)
        {
            fileReferenceName.EnsureNotNullOrWhitespace();

            var result = _getit.Query()
                                .Name("fileReferencesByName")
                                .Select("fileReferenceName")
                                .Where("fileReferenceName", fileReferenceName)
                                .Select("fileReferenceId", "fileStatusId", "workerId", "createDate", "updateDate", "isTemporaryFile")
                                .Select(GetFileStatusSubQuery())
                                .Select(GetBranchLocationSubQuery())
                                .ToString();

            return "{" + result + "}";
        }

        public string CreateFileReferenceQuery(int fileReferenceId)
        {
            fileReferenceId.Ensure(p => p > 0, $"{nameof(fileReferenceId)} must be greater then zero.");

            var result = _getit.Query()
                                .Name("fileReferenceById")
                                .Select("fileReferenceId")
                                .Where("fileReferenceId", fileReferenceId)
                                .Select("fileReferenceName", "branchLocationId","fileStatusId","workerId","createDate","updateDate","defaultGeographicLocaleId","isTemporaryFile")
                                .Select(GetFileStatusSubQuery())
                                .Select(GetBranchLocationSubQuery())
                                .Select(GetGeographicLocaleSubQuery())
                                .Select(GetTitleSearchOriginationSubQuery())
                                .Select(GetWorksheetSubQuery())
                                .Select(GetChainOfTitlesSubQuery())
                                .Select(GetFileReferenceNotesSubQuery())
                                .Select(GetSearchesSubQuery())
                                .ToString();

            return "{" + result + "}";
        }

        public string CreateUserProfileQuery(int userId, int profileId)
        {
            return null;
        }

        public string CreateUserProfilesQuery(int userId)
        {
            return null;
        }

        #region Sub queries

        private IQuery GetFileStatusSubQuery()
        {
            return _getit.Query().Name("fileStatus").Select("fileStatusId", "description");
        }

        private IQuery GetBranchLocationSubQuery()
        {
            return _getit.Query().Name("branchLocation").Select("branchLocationId", "isInternal", "accountNumber", "description");
        }

        private IQuery GetGeographicLocaleSubQuery()
        {
            return _getit.Query().Name("geographicLocale").Select("geographicLocaleId", "geographicLocaleTypeId", "localeAbbreviation", "localeName", "parentGeographicLocaleId");
        }

        private IQuery GetTitleSearchOriginationSubQuery()
        {
            return _getit.Query().Name("titleSearchOrigination").Select("titleEventId", "titleSearchOriginationId", " orderDate", "orderReference", "fileReferenceId");
        }

        private IQuery GetWorksheetSubQuery()
        {
            return _getit.Query().Name("worksheet").Select("fileReferenceId", "worksheetId");
        }

        private IQuery GetChainOfTitlesSubQuery()
        {
            return _getit.Query().Name("chainOfTitles")
                .Select("chainOfTitleId", "fileReferenceId")
                .Select(GetChainOfTitleItemsSubQuery());
        }

        private IQuery GetChainOfTitleItemsSubQuery()
        {
            return _getit.Query().Name("chainOfTitleItems")
                .Select("chainOfTitleItemId", "chainOfTitleId", "titleEventId", "orderIndex", "userModified", "startingTitleEvent")
                .Select(GetChainOfTitleCategorySubQuery());
        }

        private IQuery GetChainOfTitleCategorySubQuery()
        {
            return _getit.Query().Name("chainOfTitleCategory").Select("chainOfTitleCategoryId", "description");
        }

        private IQuery GetFileReferenceNotesSubQuery()
        {
            return _getit.Query().Name("fileReferenceNotes").Select("fileReferenceId", "fileReferenceNotesId", "message", "userId", "timeStamp");
        }

        private IQuery GetSearchesSubQuery()
        {
            return _getit.Query()
                         .Name("searches")
                         .Select("fileReferenceId",
                            "dateOfSearch",
                            "geographicCertRangeId",
                            "geographicLocaleId",
                            "giCertRangeId",
                            "instrumentFilters",
                            "parentSearchId",
                            "searchId",
                            "searchFromDate",
                            "searchThruDate",
                            "searchReference",
                            "searchStatusId",
                            "searchTypeId")
                         .Select(GetAcreageGovtLotLegalsSubQuery())
                         .Select(GetTitleEventSearchesSubQuery());
        }

        private IQuery GetAcreageGovtLotLegalsSubQuery()
        {
            return _getit.Query().Name("acreageGovtLotLegals ").Select("governmentLotId", "searchId", "unplattedReferenceId");
        }

        private IQuery GetTitleEventSearchesSubQuery()
        {
            return _getit.Query()
                         .Name("titleEventSearches ")
                         .Select("titleEventId")
                         .Select(GetTitleEventSubQuery());
        }

        private IQuery GetTitleEventSubQuery()
        {
            return _getit.Query()
                         .Name("titleEvent")
                         .Select("titleEventId",
                             "originalExamStatusTypeId",
                             "titleEventTypeId",
                             "amount",
                             "additionalInformation",
                             "titleEventDate",
                             "createDate",
                             "tag")
                         .Select(GetTitleEventTypeSubQuery())
                         .Select(GetCurrentExaminationStatusTypeSubQuery())
                         .Select(GetOriginalExaminationStatusTypeSubQuery())
                         .Select(GetTitleEventStatusAssignOfficialRecordSubQuery())
                         //.Select(GetChainOfTitleItemsSubQuery())
                         .Select(GetNameSearchListItemsSubQuery())
                         .Select(GetTitleEventGovtLotLegalMqlsSubQuery())
                         .Select(GetTitleEventNotesSubQuery())
                         .Select(GetTitleEventOrdersTrackedSubQuery())
                         .Select(GetTitleEventPartiesSubQuery())
                         .Select(GetTitleEventPlattedLegalMqlsSubQuery())
                         .Select(GetTitleEventSectionLegalMqlsSubQuery())
                         .Select(GetTitleSearchOriginationsSubQuery())
                         .Select(GetWorksheetItemsSubQuery());
        }

        private IQuery GetTitleEventTypeSubQuery()
        {
            return _getit.Query().Name("titleEventType ")
                .Select("titleEventTypeId", "eventCategoryId", "description", "titleEventCode");
        }

        private IQuery GetCurrentExaminationStatusTypeSubQuery()
        {
            return _getit.Query().Name("currentExaminationStatusType ")
                .Select("examinationStatusTypeId", "description");
        }

        private IQuery GetOriginalExaminationStatusTypeSubQuery()
        {
            return _getit.Query().Name("originalExaminationStatusType ")
                .Select("examinationStatusTypeId", "description");
        }

        private IQuery GetTitleEventStatusAssignOfficialRecordSubQuery()
        {
            return _getit.Query().Name("titleEventStatusAssignOfficialRecord")
                .Select("titleEventStatusAssignorId", "description");
        }

        private IQuery GetNameSearchListItemsSubQuery()
        {
            return _getit.Query().Name("nameSearchListItems")
                .Select("nameSearchListItemId", "legalEntityNameId", "chainOfTitleId", "nameSearchStatusCodeId", "referenceTitleEventId");
        }

        private IQuery GetTitleEventGovtLotLegalMqlsSubQuery()
        {
            return _getit.Query().Name("titleEventGovtLotLegalMqls")
                .Select("unplattedReferenceId", "governmentLotId", "titleEventId");
        }

        private IQuery GetTitleEventNotesSubQuery()
        {
            return _getit.Query().Name("titleEventNotes")
                .Select("titleEventId", "userId", "timeStamp", "message");
        }

        private IQuery GetTitleEventOrdersTrackedSubQuery()
        {
            return _getit.Query().Name("titleEventOrdersTracked")
                .Select("titleEventId", "titleEventOrderId", "deliveryOrderInfoId");
        }

        private IQuery GetTitleEventPartiesSubQuery()
        {
            return _getit.Query().Name("titleEventParties")
                .Select("titleEventId", "partyId");
        }

        private IQuery GetTitleEventPlattedLegalMqlsSubQuery()
        {
            return _getit.Query().Name("titleEventPlattedLegalMqls")
                .Select("titleEventId", "subdivisionLevelId", "platReferenceId");
        }

        private IQuery GetTitleEventSectionLegalMqlsSubQuery()
        {
            return _getit.Query().Name("titleEventSectionLegalMqls")
                .Select("titleEventId", "sectionBreakdownCodeId", "unplattedReferenceId");
        }

        private IQuery GetTitleSearchOriginationsSubQuery()
        {
            return _getit.Query().Name("titleSearchOriginations")
                .Select("titleEventId", "titleSearchOriginationId", "orderDate", "orderReference", "fileReferenceId");
        }

        private IQuery GetWorksheetItemsSubQuery()
        {
            return _getit.Query().Name("worksheetItems")
                .Select("titleEventId", "worksheetId", "sequence");
        }

        #endregion
    }
}
