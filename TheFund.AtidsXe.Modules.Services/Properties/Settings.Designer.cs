﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheFund.AtidsXe.Modules.Services.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("044078D1-0894-485B-B0EA-BCAABFC888F9")]
        public string GetFileReferencesByNameQueryId {
            get {
                return ((string)(this["GetFileReferencesByNameQueryId"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1A81CBEB-872E-42E9-954A-5E26773038F8")]
        public string GetFileReferenceByIdQueryId {
            get {
                return ((string)(this["GetFileReferenceByIdQueryId"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"query FileReferenceQuery($profileId:Int,$userId:Int){userProfileByUserIdAndProfileId(profileId:$profileId,userId:$userId){profileId userId name description createdBy createdDate modifiedBy modifiedDate userProfileFileReferences{fileReference{fileReferenceName fileReferenceId fileStatusId workerId createDate updateDate isTemporaryFile fileStatus{fileStatusId description}branchLocation{branchLocationId isInternal accountNumber description}}}}}")]
        public string GetUserProfileQueryString {
            get {
                return ((string)(this["GetUserProfileQueryString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"query FileReferenceQuery($fileReferenceName:String){fileReferencesByName(fileReferenceName:$fileReferenceName){fileReferenceName fileReferenceId fileStatusId workerId createDate updateDate isTemporaryFile fileStatus{fileStatusId description}branchLocation{branchLocationId isInternal accountNumber description}chainOfTitles{chainOfTitleId fileReferenceId}}}")]
        public string GetFileReferencesByNameQueryString {
            get {
                return ((string)(this["GetFileReferencesByNameQueryString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("query FileReferenceQuery($fileReferenceId:Int){fileReferenceById(fileReferenceId:" +
            "$fileReferenceId){fileReferenceId fileReferenceName fileStatusId workerId create" +
            "Date updateDate defaultGeographicLocaleId isTemporaryFile fileStatus{fileStatusI" +
            "d description}branchLocation{branchLocationId isInternal accountNumber descripti" +
            "on}geographicLocale{geographicLocaleId geographicLocaleTypeId localeAbbreviation" +
            " localeName parentGeographicLocaleId}titleSearchOrigination{titleEventId titleSe" +
            "archOriginationId orderDate orderReference fileReferenceId}chainOfTitles{chainOf" +
            "TitleId fileReferenceId chainOfTitleSearches{chainOfTitleId searchId search{sear" +
            "chId searchTypeId searchFromDate searchThruDate searchReference lrsSearch dateOf" +
            "Search parentSearchId}}}fileReferenceNotes{fileReferenceId fileReferenceNotesId " +
            "message userId timeStamp}searches{fileReferenceId dateOfSearch geographicCertRan" +
            "geId geographicLocaleId giCertRangeId instrumentFilters parentSearchId searchId " +
            "searchFromDate searchThruDate searchReference searchStatusId searchTypeId subdiv" +
            "isionPlattedLegals{subdivisionLevelId platReferenceId searchId plattedLegal{plat" +
            "ReferenceId subdivisionLevelId platReference{platReferenceId pageSuffix book boo" +
            "kSuffix source platProperties{platReferenceId alternateHierarchy1 alternateHiera" +
            "rchy2 platName}}subdivisionLevels{subdivisionLevelId level1 level2 level3}}}titl" +
            "eEventSearches{titleEvent{titleEventId originalExamStatusTypeId titleEventTypeId" +
            " amount additionalInformation titleEventDate createDate tag titleEventType{title" +
            "EventTypeId eventCategoryId description titleEventCode}currentExaminationStatusT" +
            "ype{examinationStatusTypeId description}originalExaminationStatusType{examinatio" +
            "nStatusTypeId description}titleEventStatusAssignOfficialRecord{titleEventStatusA" +
            "ssignorId description}nameSearchListItems{nameSearchListItemId legalEntityNameId" +
            " chainOfTitleId nameSearchStatusCodeId referenceTitleEventId}titleEventGovtLotLe" +
            "galMqls{unplattedReferenceId governmentLotId titleEventId}titleEventNotes{titleE" +
            "ventId userId timeStamp message}titleEventOrdersTracked{titleEventId titleEventO" +
            "rderId deliveryOrderInfoId}titleEventParties{titleEventId partyId}titleEventPlat" +
            "tedLegalMqls{titleEventId subdivisionLevelId platReferenceId}titleEventSearches{" +
            "titleEventId searchId}titleEventSectionLegalMqls{titleEventId sectionBreakdownCo" +
            "deId unplattedReferenceId}titleSearchOriginations{titleEventId titleSearchOrigin" +
            "ationId orderDate orderReference fileReferenceId}worksheetItems{titleEventId wor" +
            "ksheetId sequence}}}}}}")]
        public string GetFileReferenceByIdQueryString {
            get {
                return ((string)(this["GetFileReferenceByIdQueryString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mutation FileReferenceMutation($userId:Int!){deleteProfiles(userId:$userId){profi" +
            "leId userId name description createdBy createdDate modifiedBy modifiedDate userP" +
            "rofileFileReferences{profileId userId fileReferenceId}}}")]
        public string GetDeleteUserProfilesQueryString {
            get {
                return ((string)(this["GetDeleteUserProfilesQueryString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mutation FileReferenceMutation($profileId:Int!,$userId:Int!){deleteProfile(profil" +
            "eId:$profileId,userId:$userId){profileId userId name description createdBy creat" +
            "edDate modifiedBy modifiedDate userProfileFileReferences{profileId userId fileRe" +
            "ferenceId}}}")]
        public string DeleteProfileQueryString {
            get {
                return ((string)(this["DeleteProfileQueryString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"query FileReferenceQuery($userId:Int){userProfilesByUserId(userId:$userId){profileId userId name description createdBy createdDate modifiedBy modifiedDate userProfileFileReferences{profileId userId fileReferenceId fileReference{fileReferenceId fileReferenceName fileStatusId workerId createDate updateDate defaultGeographicLocaleId isTemporaryFile fileStatus{fileStatusId description} branchLocation{branchLocationId isInternal accountNumber description}}}}}")]
        public string GetUserProfilesQueryString {
            get {
                return ((string)(this["GetUserProfilesQueryString"]));
            }
        }
    }
}
