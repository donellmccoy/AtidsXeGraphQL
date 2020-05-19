using System.Linq;
using System.Reflection;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Execution;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.InputTypes;
using TheFund.AtidsXe.GraphQL.Mutations;
using TheFund.AtidsXe.GraphQL.ObjectGraphTypes;
using TheFund.AtidsXe.GraphQL.QueryTypes;
using TheFund.AtidsXe.GraphQL.Schemas;
using TheFund.AtidsXe.GraphQL.Services;
using TheFund.AtidsXe.Server.Services;
using TheFund.AtidsXe.Server.Settings;

namespace TheFund.AtidsXe.Server.Extensions
{
    //Todo: Install package 'ServicesRegistration' to auto register services
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQueryLookupServices(this IServiceCollection services)
        {
            services.AddSingleton<IQueryLookupService, QueryLookupService>();
            return services;
        }

        public static IServiceCollection AddEntityFrameworkServices(this IServiceCollection services)
        {
            services.AddSingleton<IEFDataStore, EFDataStore>();
            return services;
        }

        //Todo: Load repositories by convention from assembly
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IGenericRepository, GenericRepository>();

            services.AddTransient<IChainOfTitleRepository, ChainOfTitleRepository>();
            services.AddTransient<IChainOfTitleItemRepository, ChainOfTitleItemRepository>();
            services.AddTransient<IChainOfTitleCategoryRepository, ChainOfTitleCategoryRepository>();
            services.AddTransient<IChainOfTitleNoteRepository, ChainOfTitleNoteRepository>();
            services.AddTransient<IChainOfTitleSearchRepository, ChainOfTitleSearchRepository>();
            services.AddTransient<ISearchRepository, SearchRepository>();
            services.AddTransient<ITitleEventRepository, TitleEventRepository>();
            services.AddTransient<IFileStatusRepository, FileStatusRepository>();
            services.AddTransient<ITitleSearchOriginationRepository, TitleSearchOriginationRepository>();
            services.AddTransient<IWorksheetRepository, WorksheetRepository>();
            services.AddTransient<IBranchLocationRepository, BranchLocationRepository>();
            services.AddTransient<IGeographicLocaleRepository, GeographicLocaleRepository>();
            services.AddTransient<IFileReferenceNotesRepository, FileReferenceNotesRepository>();
            services.AddTransient<ITitleEventSearchRepository, TitleEventSearchRepository>();
            services.AddTransient<ISubdivisionPlattedLegalRepository, SubdivisionPlattedLegalRepository>();
            services.AddTransient<IAcreageSectionLegalRepository, AcreageSectionLegalRepository>();
            services.AddTransient<IAcreageGovtLotLegalRepository, AcreageGovtLotLegalRepository>();
            services.AddTransient<IPlattedLegalRepository, PlattedLegalRepository>();
            services.AddTransient<ISubdivisionLevelsRepository, SubdivisionLevelsRepository>();
            services.AddTransient<IGovernmentLotRepository, GovernmentLotRepository>();
            services.AddTransient<IGovernmentLotLegalRepository, GovernmentLotLegalRepository>();
            services.AddTransient<ISearchWarningHelpRepository, SearchWarningHelpRepository>();
            services.AddTransient<ISearchWarningRepository, SearchWarningRepository>();
            services.AddTransient<ISearchWarningTypeRepository, SearchWarningTypeRepository>();
            services.AddTransient<ISearchTypeRepository, SearchTypeRepository>();
            services.AddTransient<IWorksheetItemRepository, WorksheetItemRepository>();
            services.AddTransient<IPolicyWorksheetItemRepository, PolicyWorksheetItemRepository>();
            services.AddTransient<IPolicyRepository, PolicyRepository>();
            services.AddTransient<IGeographicCertRangeRepository, GeographicCertRangeRepository>();
            services.AddTransient<IGiCertRangeRepository, GiCertRangeRepository>();
            services.AddTransient<IGrantorCertRangeRepository, GrantorCertRangeRepository>();
            services.AddTransient<INameSearchParametersRepository, NameSearchParametersRepository>();
            services.AddTransient<IParentSearchRepository, ParentSearchRepository>();
            services.AddTransient<ISearchStatusRepository, SearchStatusRepository>();
            services.AddTransient<IPolicyTitleStatusReportRepository, PolicyTitleStatusReportRepository>();
            services.AddTransient<ITitleEventPlattedLegalMqlRepository, TitleEventPlattedLegalMqlRepository>();
            services.AddTransient<IPolicyPlattedLegalMqlRepository, PolicyPlattedLegalMqlRepository>();
            services.AddTransient<IPlatReferenceRepository, PlatReferenceRepository>();

            return services;
        }

        public static IServiceCollection AddGraphQLServices(this IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(serviceProvider => new FuncDependencyResolver(serviceProvider.GetService));
            
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<IDocumentExecutionListener, DataLoaderDocumentListener>();

            services.AddSingleton<ISchema, AtidsXeSchema>();
            services.AddSingleton<TitleEventInputType>();
            services.AddSingleton<TitleQuery>();
            services.AddSingleton<FileReferenceQuery>();
            services.AddSingleton<FileReferenceMutation>();

            services.AddSingleton<AcreageGovtLotLegalGraphType>();
            services.AddSingleton<AcreageSectionLegalGraphType>();
            services.AddSingleton<BookPageReferenceGraphType>();
            services.AddSingleton<BranchLocationGraphType>();
            services.AddSingleton<BreakdownCodeTypeGraphType>();
            services.AddSingleton<CaseNumberReferenceGraphType>();
            services.AddSingleton<CertificationRangeGraphType>();
            services.AddSingleton<ChainOfTitleGraphType>();
            services.AddSingleton<ChainOfTitleCategoryGraphType>();
            services.AddSingleton<ChainOfTitleItemGraphType>();
            services.AddSingleton<ChainOfTitleNotesGraphType>();
            services.AddSingleton<ChainOfTitleSearchGraphType>();
            services.AddSingleton<DeliveryOrderInfoGraphType>();
            services.AddSingleton<ExaminationStatusTypeGraphType>();
            services.AddSingleton<FileReferenceGraphType>();
            services.AddSingleton<FileReferenceNotesGraphType>();
            services.AddSingleton<FileStatusGraphType>();
            services.AddSingleton<GeographicLocaleGraphType>();
            services.AddSingleton<GeographicLocaleTypeGraphType>();
            services.AddSingleton<GovernmentLotGraphType>();
            services.AddSingleton<GovernmentLotLegalGraphType>();
            services.AddSingleton<LegalEntityNameGraphType>();
            services.AddSingleton<LegalEntityNameTypeGraphType>();
            services.AddSingleton<MinNumberGraphType>();
            services.AddSingleton<MortgageTitleEventGraphType>();
            services.AddSingleton<NameReasonCodeGraphType>();
            services.AddSingleton<NameSearchListItemGraphType>();
            services.AddSingleton<NameSearchListReasonCodeGraphType>();
            services.AddSingleton<NameSearchParametersGraphType>();
            services.AddSingleton<NameSearchStatusCodeGraphType>();
            services.AddSingleton<OfficialRecordDocumentGraphType>();
            services.AddSingleton<OrDocumentInformationGraphType>();
            services.AddSingleton<OwnerBuyerRelationshipGraphType>();
            services.AddSingleton<PartyGraphType>();
            services.AddSingleton<PartyLegalEntityNameGraphType>();
            services.AddSingleton<PartyRoleTypeGraphType>();
            services.AddSingleton<PersonalLegalEntityNameGraphType>();
            services.AddSingleton<PlatPropertiesGraphType>();
            services.AddSingleton<PlatReferenceGraphType>();
            services.AddSingleton<PlattedLegalGraphType>();
            services.AddSingleton<PolicyGraphType>();
            services.AddSingleton<PolicyGovtLotLegalMqlGraphType>();
            services.AddSingleton<PolicyInsuredDocumentGraphType>();
            services.AddSingleton<PolicyNotesGraphType>();
            services.AddSingleton<PolicyOrderGraphType>();
            services.AddSingleton<PolicyOrderTrackingGraphType>();
            services.AddSingleton<PolicyPlattedLegalMqlGraphType>();
            services.AddSingleton<PolicyRestrictionTypeGraphType>();
            services.AddSingleton<PolicySearchGraphType>();
            services.AddSingleton<PolicySectionLegalMqlGraphType>();
            services.AddSingleton<PolicyTitleStatusReportGraphType>();
            services.AddSingleton<PolicyWorksheetItemGraphType>();
            services.AddSingleton<PropertyAddressGraphType>();
            services.AddSingleton<RelatedCaseNumberGraphType>();
            services.AddSingleton<RelatedOfficialRecordDocumentGraphType>();
            services.AddSingleton<RelatedTaxFolioGraphType>();
            services.AddSingleton<SearchGraphType>();
            services.AddSingleton<SearchNotesGraphType>();
            services.AddSingleton<SearchStatusGraphType>();
            services.AddSingleton<SearchTypeGraphType>();
            services.AddSingleton<SearchWarningGraphType>();
            services.AddSingleton<SearchWarningHelpGraphType>();
            services.AddSingleton<SearchWarningTypeGraphType>();
            services.AddSingleton<SectionBreakdownCodeGraphType>();
            services.AddSingleton<SectionLegalGraphType>();
            services.AddSingleton<SubdivisionLevelsGraphType>();
            services.AddSingleton<SubdivisionPlattedLegalGraphType>();
            services.AddSingleton<TaxFolioReferenceGraphType>();
            services.AddSingleton<TitleEventGraphType>();
            services.AddSingleton<TitleEventDocumentGraphType>();
            services.AddSingleton<TitleEventGovtLotLegalMqlGraphType>();
            services.AddSingleton<TitleEventLegalEntityMqlGraphType>();
            services.AddSingleton<TitleEventNotesGraphType>();
            services.AddSingleton<TitleEventOrderTrackingGraphType>();
            services.AddSingleton<TitleEventPartyGraphType>();
            services.AddSingleton<TitleEventPlattedLegalMqlGraphType>();
            services.AddSingleton<TitleEventSearchGraphType>();
            services.AddSingleton<TitleEventSectionLegalMqlGraphType>();
            services.AddSingleton<TitleEventStatusAssignOfficialRecordGraphType>();
            services.AddSingleton<TitleEventTypeGraphType>();
            services.AddSingleton<TitleEventTypeCategoryGraphType>();
            services.AddSingleton<TitleSearchOriginationGraphType>();
            services.AddSingleton<TownshipDirectionTypeGraphType>();
            services.AddSingleton<TypeOfInstrumentGraphType>();
            services.AddSingleton<UnplattedReferenceGraphType>();
            services.AddSingleton<WorksheetGraphType>();
            services.AddSingleton<WorksheetItemGraphType>();
            services.AddSingleton<YearNumberReferenceGraphType>();

            services.AddSingleton<UserGraphType>();
            services.AddSingleton<UserProfileGraphType>();
            services.AddSingleton<UserProfileFileReferenceGraphType>();

            return services;
        }

        public static IServiceCollection AddDbContextServices(
            this IServiceCollection services, 
            IDbContextSettings contextSettings, 
            IDbConnectionStrings connectionStrings,
            IWebHostEnvironment hostingEnvironment)
        {
            void CreateOptionsAction(DbContextOptionsBuilder builder)
            {
                builder.EnableDetailedErrors(!hostingEnvironment.IsProduction());
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                builder.UseSqlServer
                (
                    connectionStrings.SqlConnectionStrings.AtidsXe,
                    _ =>
                    {
                        _.EnableRetryOnFailure(contextSettings.MaxRetryCount, contextSettings.MaxRetryDelayTimeSpan, null);
                        _.CommandTimeout(contextSettings.CommandTimeout);
                    });
            }

            if (contextSettings.EnablePooling)
            {
                services.AddDbContextPool<ATIDSXEContext>(CreateOptionsAction, contextSettings.PoolSize);
            }
            else
            {
                services.AddDbContext<ATIDSXEContext>(CreateOptionsAction, ServiceLifetime.Transient, ServiceLifetime.Transient);
            }

            return services;
        }
    }
}
