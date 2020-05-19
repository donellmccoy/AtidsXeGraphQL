using GraphQL.Types;
using System.Collections.Generic;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Properties;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class OfficialRecordDocumentGraphType : ObjectGraphType<OfficialRecordDocument>
    {
        private readonly IEFDataStore _dataStore;

        public OfficialRecordDocumentGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            InitializeGraphTypes();
            InitialzieListGraphTypes();
        }

        private void InitializeGraphTypes()
        {
            Field(p => p.OfficialRecordDocumentId);
            Field(p => p.GeographicLocaleId, true);
        }

        private void InitialzieListGraphTypes()
        {
            #region CertificationRangeTypesFromOfficialRecordDocuments

            FieldAsync<ListGraphType<CertificationRangeGraphType>, IEnumerable<CertificationRange>>
            (
                FieldNames.CertificationRangeTypesFromOfficialRecordDocument,
                Resources.Certification_range_types_from_this_official_record_document,
                CreateQueryArguments(),
                context => 
                {
                    return _dataStore.GetBatchedEntitiesAsync<CertificationRange>
                    (
                        LoaderKeys.CertificationRangeTypesFromOfficialRecordDocuments,
                        context.Source.OfficialRecordDocumentId,
                        p => p.FromOrDocumentId, 
                        context.CancellationToken
                    );
                });

            #endregion

            #region CertificationRangeTypesToOfficialRecordDocuments

            FieldAsync<ListGraphType<CertificationRangeGraphType>, IEnumerable<CertificationRange>>
            (
                FieldNames.CertificationRangeTypesToOfficialRecordDocument,
                Resources.Certification_range_types_to_this_official_record_document,
                CreateQueryArguments(),
                context => 
                {
                    return _dataStore.GetBatchedEntitiesAsync<CertificationRange>
                    (
                        LoaderKeys.CertificationRangeTypesToOfficialRecordDocuments,
                        context.Source.OfficialRecordDocumentId,
                        p => p.ToOrDocumentId, 
                        context.CancellationToken
                    );
                });

            #endregion

            #region Local methods

            QueryArguments CreateQueryArguments()
            {
                return new QueryArguments
                (
                    new QueryArgument<IntGraphType>
                    {
                        Name = ArgumentNames.OfficialRecordDocumentId
                    }
                );
            }

            #endregion
        }
    }
}
