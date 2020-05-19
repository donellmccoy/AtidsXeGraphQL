using GraphQL.Types;
using System;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class TitleEventGraphType : ObjectGraphTypeBase<TitleEvent>
    {
        public TitleEventGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(TitleEventGraphType);
            Description = nameof(TitleEventGraphType);

            InitializePrimitiveTypes();
            InitializeComplexTypes();
            InitializeCollectionTypes();
        }

        private void InitializePrimitiveTypes()
        {
            Field(p => p.TitleEventId);
            Field(p => p.CurrentExamStatusTypeId);
            Field(p => p.OriginalExamStatusTypeId);
            Field(p => p.TitleEventStatusAssignorId);
            Field(p => p.TitleEventTypeId);
            Field(p => p.Amount, true).DefaultValue(0m);
            Field(p => p.TitleEventDate, true).DefaultValue(DateTime.MinValue);
            Field(p => p.CreateDate, true).DefaultValue(DateTime.MinValue);
            Field<StringGraphType>(
                FieldNames.AdditionalInformation,
                context => context.Source.AdditionalInformation.TrimIfNotNull());
            Field<StringGraphType>(
                FieldNames.Tag,
                context => context.Source.Tag.TrimIfNotNull());
        }

        private void InitializeComplexTypes()
        {
            Field<ExaminationStatusTypeGraphType, ExaminationStatusType>(
                FieldNames.CurrentExaminationStatusType,
                titleEvent => titleEvent.CurrentExamStatusTypeId,
                examinationStatusType => examinationStatusType.ExaminationStatusTypeId);

            Field<ExaminationStatusTypeGraphType, ExaminationStatusType>(
                FieldNames.OriginalExaminationStatusType,
                titleEvent => titleEvent.OriginalExamStatusTypeId,
                examinationStatusType => examinationStatusType.ExaminationStatusTypeId);

            Field<TitleEventStatusAssignOfficialRecordGraphType, TitleEventStatusAssignor>(
                FieldNames.TitleEventStatusAssignOfficialRecord,
                titleEvent => titleEvent.TitleEventStatusAssignorId,
                titleEventStatusAssignor => titleEventStatusAssignor.TitleEventStatusAssignorId);

            Field<TitleEventTypeGraphType, TitleEventType>(
                FieldNames.TitleEventType,
                titleEvent => titleEvent.TitleEventTypeId,
                titleEventType => titleEventType.TitleEventTypeId);

            Field<MortgageTitleEventGraphType, MortgageTitleEvent>(
                FieldNames.MortgageTitleEvent,
                titleEvent => titleEvent.TitleEventId,
                mortgageTitleEvent => mortgageTitleEvent.TitleEventId);
        }

        private void InitializeCollectionTypes()
        {
            Func<TitleEvent, int> predicate = titleEvent => titleEvent.TitleEventId;

            FieldListAsync<ChainOfTitleItemGraphType, ChainOfTitleItem>(
                FieldNames.ChainOfTitleItems,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<NameSearchListItemGraphType, NameSearchListItem>(
                FieldNames.NameSearchListItems,
                predicate,
                p => p.ReferenceTitleEventId);

            FieldListAsync<TitleEventGovtLotLegalMqlGraphType, TitleEventGovtLotLegalMql>(
                FieldNames.TitleEventGovtLotLegalMqls,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleEventLegalEntityMqlGraphType, TitleEventLegalEntityMql>(
                FieldNames.TitleEventLegalEntityMqls,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleEventNotesGraphType, TitleEventNotes>(
                FieldNames.TitleEventNotes,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleEventOrderTrackingGraphType, TitleEventOrderTracking>(
                FieldNames.TitleEventOrdersTracked,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleEventPartyGraphType, TitleEventParty>(
                FieldNames.TitleEventParties,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleEventPlattedLegalMqlGraphType, TitleEventPlattedLegalMql>(
                FieldNames.TitleEventPlattedLegalMqls,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleEventSearchGraphType, TitleEventSearch>(
                FieldNames.TitleEventSearches,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleEventSectionLegalMqlGraphType, TitleEventSectionLegalMql>(
                FieldNames.TitleEventSectionLegalMqls,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<TitleSearchOriginationGraphType, TitleSearchOrigination>(
                FieldNames.TitleSearchOriginations,
                predicate,
                p => p.TitleEventId);

            FieldListAsync<WorksheetItemGraphType, WorksheetItem>(
                FieldNames.WorksheetItems,
                predicate,
                p => p.TitleEventId);


            QueryArguments CreateQueryArguments()
            {
                return new QueryArguments
                (
                    new QueryArgument<IntGraphType>
                    {
                        Name = ArgumentNames.TitleEventId
                    }
                );
            }
        }
    }
}