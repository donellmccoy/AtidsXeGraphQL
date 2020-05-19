using Microsoft.EntityFrameworkCore;

namespace TheFund.AtidsXe.Entities.Models
{
    public partial class ATIDSXEContext : DbContext
    {
        public ATIDSXEContext()
        {
        }

        public ATIDSXEContext(DbContextOptions<ATIDSXEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcreageGovtLotLegal> AcreageGovtLotLegal { get; set; }
        public virtual DbSet<AcreageSectionLegal> AcreageSectionLegal { get; set; }
        public virtual DbSet<BookPageReference> BookPageReference { get; set; }
        public virtual DbSet<BranchLocation> BranchLocation { get; set; }
        public virtual DbSet<BreakdownCodeType> BreakdownCodeType { get; set; }
        public virtual DbSet<CaseNumberReference> CaseNumberReference { get; set; }
        public virtual DbSet<CertificationRange> CertificationRange { get; set; }
        public virtual DbSet<ChainOfTitle> ChainOfTitle { get; set; }
        public virtual DbSet<ChainOfTitleCategory> ChainOfTitleCategory { get; set; }
        public virtual DbSet<ChainOfTitleItem> ChainOfTitleItem { get; set; }
        public virtual DbSet<ChainOfTitleNotes> ChainOfTitleNotes { get; set; }
        public virtual DbSet<ChainOfTitleSearch> ChainOfTitleSearch { get; set; }
        public virtual DbSet<DeliveryOrderInfo> DeliveryOrderInfo { get; set; }
        public virtual DbSet<ExaminationStatusType> ExaminationStatusType { get; set; }
        public virtual DbSet<FileReference> FileReference { get; set; }
        public virtual DbSet<FileReferenceNotes> FileReferenceNotes { get; set; }
        public virtual DbSet<FileStatus> FileStatus { get; set; }
        public virtual DbSet<GeographicLocale> GeographicLocale { get; set; }
        public virtual DbSet<GeographicLocaleType> GeographicLocaleType { get; set; }
        public virtual DbSet<GovernmentLot> GovernmentLot { get; set; }
        public virtual DbSet<GovernmentLotLegal> GovernmentLotLegal { get; set; }
        public virtual DbSet<LegalEntityName> LegalEntityName { get; set; }
        public virtual DbSet<LegalEntityNameType> LegalEntityNameType { get; set; }
        public virtual DbSet<MinNumber> MinNumber { get; set; }
        public virtual DbSet<MortgageTitleEvent> MortgageTitleEvent { get; set; }
        public virtual DbSet<NameReasonCode> NameReasonCode { get; set; }
        public virtual DbSet<NameSearchListItem> NameSearchListItem { get; set; }
        public virtual DbSet<NameSearchListReasonCode> NameSearchListReasonCode { get; set; }
        public virtual DbSet<NameSearchParameters> NameSearchParameters { get; set; }
        public virtual DbSet<NameSearchStatusCode> NameSearchStatusCode { get; set; }
        public virtual DbSet<OfficialRecordDocument> OfficialRecordDocument { get; set; }
        public virtual DbSet<OrDocumentInformation> OrDocumentInformation { get; set; }
        public virtual DbSet<OwnerBuyerRelationship> OwnerBuyerRelationship { get; set; }
        public virtual DbSet<Party> Party { get; set; }
        public virtual DbSet<PartyLegalEntityName> PartyLegalEntityName { get; set; }
        public virtual DbSet<PartyRoleType> PartyRoleType { get; set; }
        public virtual DbSet<PersonalLegalEntityName> PersonalLegalEntityName { get; set; }
        public virtual DbSet<PlatProperties> PlatProperties { get; set; }
        public virtual DbSet<PlatReference> PlatReference { get; set; }
        public virtual DbSet<PlattedLegal> PlattedLegal { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<PolicyGovtLotLegalMql> PolicyGovtLotLegalMql { get; set; }
        public virtual DbSet<PolicyInsuredDocument> PolicyInsuredDocument { get; set; }
        public virtual DbSet<PolicyNotes> PolicyNotes { get; set; }
        public virtual DbSet<PolicyOrder> PolicyOrder { get; set; }
        public virtual DbSet<PolicyOrderTracking> PolicyOrderTracking { get; set; }
        public virtual DbSet<PolicyPlattedLegalMql> PolicyPlattedLegalMql { get; set; }
        public virtual DbSet<PolicyRestrictionType> PolicyRestrictionType { get; set; }
        public virtual DbSet<PolicySearch> PolicySearch { get; set; }
        public virtual DbSet<PolicySectionLegalMql> PolicySectionLegalMql { get; set; }
        public virtual DbSet<PolicyTitleStatusReport> PolicyTitleStatusReport { get; set; }
        public virtual DbSet<PolicyWorksheetItem> PolicyWorksheetItem { get; set; }
        public virtual DbSet<PropertyAddress> PropertyAddress { get; set; }
        public virtual DbSet<RangeDirectionType> RangeDirectionType { get; set; }
        public virtual DbSet<RelatedCaseNumber> RelatedCaseNumber { get; set; }
        public virtual DbSet<RelatedOrDocument> RelatedOrDocument { get; set; }
        public virtual DbSet<RelatedTaxFolio> RelatedTaxFolio { get; set; }
        public virtual DbSet<Search> Search { get; set; }
        public virtual DbSet<SearchNotes> SearchNotes { get; set; }
        public virtual DbSet<SearchStatus> SearchStatus { get; set; }
        public virtual DbSet<SearchType> SearchType { get; set; }
        public virtual DbSet<SearchWarning> SearchWarning { get; set; }
        public virtual DbSet<SearchWarningHelp> SearchWarningHelp { get; set; }
        public virtual DbSet<SearchWarningType> SearchWarningType { get; set; }
        public virtual DbSet<SectionBreakdownCode> SectionBreakdownCode { get; set; }
        public virtual DbSet<SectionLegal> SectionLegal { get; set; }
        public virtual DbSet<SubdivisionLevels> SubdivisionLevels { get; set; }
        public virtual DbSet<SubdivisionPlattedLegal> SubdivisionPlattedLegal { get; set; }
        public virtual DbSet<TaxFolioReference> TaxFolioReference { get; set; }
        public virtual DbSet<TitleEvent> TitleEvent { get; set; }
        public virtual DbSet<TitleEventDocument> TitleEventDocument { get; set; }
        public virtual DbSet<TitleEventGovtLotLegalMql> TitleEventGovtLotLegalMql { get; set; }
        public virtual DbSet<TitleEventLegalEntityMql> TitleEventLegalEntityMql { get; set; }
        public virtual DbSet<TitleEventNotes> TitleEventNotes { get; set; }
        public virtual DbSet<TitleEventOrder> TitleEventOrder { get; set; }
        public virtual DbSet<TitleEventOrderTracking> TitleEventOrderTracking { get; set; }
        public virtual DbSet<TitleEventParty> TitleEventParty { get; set; }
        public virtual DbSet<TitleEventPlattedLegalMql> TitleEventPlattedLegalMql { get; set; }
        public virtual DbSet<TitleEventSearch> TitleEventSearch { get; set; }
        public virtual DbSet<TitleEventSectionLegalMql> TitleEventSectionLegalMql { get; set; }
        public virtual DbSet<TitleEventStatusAssignor> TitleEventStatusAssignor { get; set; }
        public virtual DbSet<TitleEventType> TitleEventType { get; set; }
        public virtual DbSet<TitleEventTypeCategory> TitleEventTypeCategory { get; set; }
        public virtual DbSet<TitleSearchOrigination> TitleSearchOrigination { get; set; }
        public virtual DbSet<TownshipDirectionType> TownshipDirectionType { get; set; }
        public virtual DbSet<TypeOfInstrument> TypeOfInstrument { get; set; }
        public virtual DbSet<UnplattedReference> UnplattedReference { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserProfileFileReference> UserProfileFileReference { get; set; }
        public virtual DbSet<Worksheet> Worksheet { get; set; }
        public virtual DbSet<WorksheetItem> WorksheetItem { get; set; }
        public virtual DbSet<YearNumberReference> YearNumberReference { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AcreageGovtLotLegal>(entity =>
            {
                entity.HasKey(e => new { e.SearchId, e.GovernmentLotId, e.UnplattedReferenceId });

                entity.HasIndex(e => e.GovernmentLotId)
                    .HasName("I_FK_ACREAGE_GOVT_LOT_LEGAL_GOVERNMENT_LOT_ID");

                entity.HasIndex(e => e.UnplattedReferenceId)
                    .HasName("I_FK_ACREAGE_GOVT_LOT_LEGAL_UNPLATTED_REFERENCE_ID");

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.AcreageGovtLotLegal)
                    .HasForeignKey(d => d.SearchId)
                    .HasConstraintName("FK_ACRE_GOVT_LOT_LGL_SRCH");

                entity.HasOne(d => d.GovernmentLotLegal)
                    .WithMany(p => p.AcreageGovtLotLegal)
                    .HasForeignKey(d => new { d.UnplattedReferenceId, d.GovernmentLotId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACREAGE_GOVT_LOT_LEGAL_GOVERNMENT_LOT_LEGAL");
            });

            modelBuilder.Entity<AcreageSectionLegal>(entity =>
            {
                entity.HasKey(e => new { e.SearchId, e.SectionBreakdownCodeId, e.UnplattedReferenceId });

                entity.HasIndex(e => e.SectionBreakdownCodeId)
                    .HasName("I_FK_ACREAGE_SECTION_LEGAL_SECTION_BREAKDOWN_CODE_ID");

                entity.HasIndex(e => e.UnplattedReferenceId)
                    .HasName("I_FK_ACREAGE_SECTION_LEGAL_UNPLATTED_REFERENCE_ID");

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.AcreageSectionLegal)
                    .HasForeignKey(d => d.SearchId)
                    .HasConstraintName("FK_ACREAGE_SECT_LGL_SRCH");

                entity.HasOne(d => d.SectionLegal)
                    .WithMany(p => p.AcreageSectionLegal)
                    .HasForeignKey(d => new { d.SectionBreakdownCodeId, d.UnplattedReferenceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECT_LEGAL_ACREAGE_SEARCH");
            });

            modelBuilder.Entity<BookPageReference>(entity =>
            {
                entity.Property(e => e.OfficialRecordDocumentId).ValueGeneratedNever();

                entity.Property(e => e.Book).IsUnicode(false);

                entity.Property(e => e.BookSuffix).IsUnicode(false);

                entity.Property(e => e.Page).IsUnicode(false);

                entity.Property(e => e.PageSuffix).IsUnicode(false);

                entity.Property(e => e.Source).IsUnicode(false);

                entity.HasOne(d => d.OfficialRecordDocument)
                    .WithOne(p => p.BookPageReference)
                    .HasForeignKey<BookPageReference>(d => d.OfficialRecordDocumentId)
                    .HasConstraintName("FK_ORD_BOOK_PAGE_REFERENCE");
            });

            modelBuilder.Entity<BranchLocation>(entity =>
            {
                entity.HasIndex(e => e.AccountNumber)
                    .HasName("IX_BRANCH_LOCATION_ACCOUNT")
                    .IsUnique();

                entity.Property(e => e.AccountNumber).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<BreakdownCodeType>(entity =>
            {
                entity.Property(e => e.BreakdownCodeTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<CaseNumberReference>(entity =>
            {
                entity.HasIndex(e => e.GeographicLocaleId)
                    .HasName("I_FK_GEOGRAPHIC_LOCALE");

                entity.HasIndex(e => new { e.Source, e.RecordingYear, e.RecordingNumber, e.Suffix, e.SeriesCode, e.GeographicLocaleId })
                    .HasName("CASE_NUMBER_REFERENCE_UC1")
                    .IsUnique();

                entity.Property(e => e.SeriesCode).IsUnicode(false);

                entity.Property(e => e.Source).IsUnicode(false);

                entity.Property(e => e.Suffix).IsUnicode(false);

                entity.HasOne(d => d.GeographicLocale)
                    .WithMany(p => p.CaseNumberReference)
                    .HasForeignKey(d => d.GeographicLocaleId)
                    .HasConstraintName("FK_GEO_LOCALE_CASE_NBR_REF");
            });

            modelBuilder.Entity<CertificationRange>(entity =>
            {
                entity.HasIndex(e => e.ToOrDocumentId)
                    .HasName("I_FK_CERTIFICATION_RANGE_TO_OR_DOCUMENT_ID");

                entity.HasIndex(e => new { e.FromOrDocumentId, e.ToOrDocumentId })
                    .HasName("I_FK_DOCUMENT");

                entity.HasOne(d => d.FromOrDocument)
                    .WithMany(p => p.CertificationRangeFromOrDocument)
                    .HasForeignKey(d => d.FromOrDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORD_CERT_RANGE_FROM");

                entity.HasOne(d => d.ToOrDocument)
                    .WithMany(p => p.CertificationRangeToOrDocument)
                    .HasForeignKey(d => d.ToOrDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORD_CERT_RANGE_TO");
            });

            modelBuilder.Entity<ChainOfTitle>(entity =>
            {
                entity.HasIndex(e => e.FileReferenceId)
                    .HasName("I_FK_CHAIN_OF_TITLE_FILE_REFERENCE_ID");

                entity.HasOne(d => d.FileReference)
                    .WithMany(p => p.ChainOfTitle)
                    .HasForeignKey(d => d.FileReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAIN_OF_TITLE_FILE_REFERENCE");
            });

            modelBuilder.Entity<ChainOfTitleCategory>(entity =>
            {
                entity.HasIndex(e => e.ChainOfTitleCategoryId)
                    .HasName("COT_CATEGORY_DESCRIPTION_UC1")
                    .IsUnique();

                entity.Property(e => e.ChainOfTitleCategoryId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<ChainOfTitleItem>(entity =>
            {
                entity.HasIndex(e => e.ChainOfTitleCategoryId)
                    .HasName("I_FK_CHAIN_OF_TITLE_ITEM_CHAIN_OF_TITLE_CATEGORY_ID");

                entity.HasIndex(e => e.ChainOfTitleId)
                    .HasName("I_FK_CHAIN_OF_TITLE_ITEM_CHAIN_OF_TITLE_ID");

                entity.HasIndex(e => e.TitleEventId)
                    .HasName("I_FK_CHAIN_OF_TITLE_ITEM_TITLE_EVENT_ID");

                entity.HasOne(d => d.ChainOfTitleCategory)
                    .WithMany(p => p.ChainOfTitleItem)
                    .HasForeignKey(d => d.ChainOfTitleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAIN_OF_TITLE_ITEM_CHAIN_OF_TITLE_CATEGORY");

                entity.HasOne(d => d.ChainOfTitle)
                    .WithMany(p => p.ChainOfTitleItem)
                    .HasForeignKey(d => d.ChainOfTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAIN_OF_TITLE_ITEM_CHAIN_OF_TITLE");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.ChainOfTitleItem)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAIN_OF_TITLE_ITEM_TITLE_EVENT");
            });

            modelBuilder.Entity<ChainOfTitleNotes>(entity =>
            {
                entity.HasIndex(e => e.ChainOfTitleId)
                    .HasName("I_FK_CHAIN_OF_TITLE_NOTES_CHAIN_OF_TITLE_ID");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.ChainOfTitle)
                    .WithMany(p => p.ChainOfTitleNotes)
                    .HasForeignKey(d => d.ChainOfTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAIN_OF_TITLE_NOTES_CHAIN_OF_TITLE");
            });

            modelBuilder.Entity<ChainOfTitleSearch>(entity =>
            {
                entity.HasKey(e => new { e.SearchId, e.ChainOfTitleId })
                    .HasName("PK_CHAIN_OF_TITLE_SEARCH_1");

                entity.HasIndex(e => e.SearchId);

                entity.HasOne(d => d.ChainOfTitle)
                    .WithMany(p => p.ChainOfTitleSearch)
                    .HasForeignKey(d => d.ChainOfTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAIN_OF_TITLE_SEARCH_CHAIN_OF_TITLE");

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.ChainOfTitleSearch)
                    .HasForeignKey(d => d.SearchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAIN_OF_TITLE_SEARCH_SEARCH");
            });

            modelBuilder.Entity<DeliveryOrderInfo>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PageCount).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ExaminationStatusType>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("EXAMINATION_STATUS_TYPE_UC1")
                    .IsUnique();

                entity.Property(e => e.ExaminationStatusTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<FileReference>(entity =>
            {
                entity.HasIndex(e => e.BranchLocationId)
                    .HasName("I_FK_BRANCH_LOCATION");

                entity.HasIndex(e => e.DefaultGeographicLocaleId)
                    .HasName("I_FK_FILE_REFERENCE_DEFAULT_GEOGRAPHIC_LOCALE_ID");

                entity.HasIndex(e => e.FileStatusId)
                    .HasName("I_FK_STATUS");

                entity.HasIndex(e => new { e.FileReference1, e.BranchLocationId })
                    .HasName("I_FILE_REFERENCE")
                    .IsUnique();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileReference1).IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WorkerId).IsUnicode(false);

                entity.HasOne(d => d.BranchLocation)
                    .WithMany(p => p.FileReference)
                    .HasForeignKey(d => d.BranchLocationId)
                    .HasConstraintName("FK_BRANCH_LOC_FILE_REFERENCE");

                entity.HasOne(d => d.DefaultGeographicLocale)
                    .WithMany(p => p.FileReference)
                    .HasForeignKey(d => d.DefaultGeographicLocaleId)
                    .HasConstraintName("FK_LOCATION_FILE_REFERENCE");

                entity.HasOne(d => d.FileStatus)
                    .WithMany(p => p.FileReference)
                    .HasForeignKey(d => d.FileStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILE_STATUS_FILE_REFERENCE");
            });

            modelBuilder.Entity<FileReferenceNotes>(entity =>
            {
                entity.HasIndex(e => e.FileReferenceId)
                    .HasName("I_FK_FILE_REFERENCE");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.FileReference)
                    .WithMany(p => p.FileReferenceNotes)
                    .HasForeignKey(d => d.FileReferenceId)
                    .HasConstraintName("FK_FILE_REFERENCE_NOTES");
            });

            modelBuilder.Entity<FileStatus>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("FILE_STATUS_UC1")
                    .IsUnique();

                entity.Property(e => e.FileStatusId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<GeographicLocale>(entity =>
            {
                entity.HasIndex(e => e.GeographicLocaleTypeId)
                    .HasName("I_FK_GEOGRAPHIC_LOCALE_TYPE");

                entity.HasIndex(e => e.ParentGeographicLocaleId)
                    .HasName("I_FK_PARENT_GEO_LOCALE_ID");

                entity.HasIndex(e => new { e.LocaleName, e.GeographicLocaleTypeId, e.ParentGeographicLocaleId })
                    .HasName("UK_GEOGRAPHIC_LOCALE")
                    .IsUnique();

                entity.Property(e => e.LocaleAbbreviation).IsUnicode(false);

                entity.Property(e => e.LocaleName).IsUnicode(false);

                entity.HasOne(d => d.GeographicLocaleType)
                    .WithMany(p => p.GeographicLocale)
                    .HasForeignKey(d => d.GeographicLocaleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GEO_LOCALETYPE_GEO_LOCALE");

                entity.HasOne(d => d.ParentGeographicLocale)
                    .WithMany(p => p.InverseParentGeographicLocale)
                    .HasForeignKey(d => d.ParentGeographicLocaleId)
                    .HasConstraintName("FK_GEO_LOCALE_PARENT_LOCALE");
            });

            modelBuilder.Entity<GeographicLocaleType>(entity =>
            {
                entity.HasIndex(e => e.TypeName)
                    .HasName("GEOGRAPHIC_LOCALE_TYPE_UC1")
                    .IsUnique();

                entity.Property(e => e.GeographicLocaleTypeId).ValueGeneratedNever();

                entity.Property(e => e.TypeName).IsUnicode(false);
            });

            modelBuilder.Entity<GovernmentLot>(entity =>
            {
                entity.HasIndex(e => e.GovernmentLotNumber)
                    .HasName("GOVERNMENT_LOT_UC1")
                    .IsUnique();

                entity.Property(e => e.GovernmentLotNumber).IsUnicode(false);
            });

            modelBuilder.Entity<GovernmentLotLegal>(entity =>
            {
                entity.HasKey(e => new { e.UnplattedReferenceId, e.GovernmentLotId });

                entity.HasIndex(e => e.GovernmentLotId)
                    .HasName("I_FK_GOVERNMENT_LOT_LEGAL_GOVERNMENT_LOT_ID");

                entity.HasOne(d => d.GovernmentLot)
                    .WithMany(p => p.GovernmentLotLegal)
                    .HasForeignKey(d => d.GovernmentLotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GOVT_LOT_GOVT_LOT_LEGAL");

                entity.HasOne(d => d.UnplattedReference)
                    .WithMany(p => p.GovernmentLotLegal)
                    .HasForeignKey(d => d.UnplattedReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UNPLAT_REF_GOVT_LOT_LEGAL");
            });

            modelBuilder.Entity<LegalEntityName>(entity =>
            {
                entity.HasIndex(e => e.LegalEntityNameTypeId)
                    .HasName("I_FK_LEGAL_ENTITY_NAME_TYPE");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.UnparsedLegalEntityName).IsUnicode(false);

                entity.HasOne(d => d.LegalEntityNameType)
                    .WithMany(p => p.LegalEntityName)
                    .HasForeignKey(d => d.LegalEntityNameTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LGLENT_NMTYP_LGLENT_NAME");
            });

            modelBuilder.Entity<LegalEntityNameType>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("IX_LEGAL_ENTITY_NAME_DESC");

                entity.Property(e => e.LegalEntityNameTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<MinNumber>(entity =>
            {
                entity.HasIndex(e => new { e.MinLender, e.MinSerial, e.MinCheckDigit })
                    .HasName("MIN_NUMBER_UC1")
                    .IsUnique();

                entity.Property(e => e.MinCheckDigit).IsUnicode(false);

                entity.Property(e => e.MinLender).IsUnicode(false);

                entity.Property(e => e.MinSerial).IsUnicode(false);
            });

            modelBuilder.Entity<MortgageTitleEvent>(entity =>
            {
                entity.HasIndex(e => e.MinNumberId)
                    .HasName("I_FK_MIN_NUMBER");

                entity.Property(e => e.TitleEventId).ValueGeneratedNever();

                entity.Property(e => e.LenderName).IsUnicode(false);

                entity.HasOne(d => d.MinNumber)
                    .WithMany(p => p.MortgageTitleEvent)
                    .HasForeignKey(d => d.MinNumberId)
                    .HasConstraintName("FK_MIN_NBR_MTG_TITLE_EVENT");

                entity.HasOne(d => d.TitleEvent)
                    .WithOne(p => p.MortgageTitleEvent)
                    .HasForeignKey<MortgageTitleEvent>(d => d.TitleEventId)
                    .HasConstraintName("FK_TITLE_EVENT_MTG_TITLE_EVENT");
            });

            modelBuilder.Entity<NameReasonCode>(entity =>
            {
                entity.HasIndex(e => e.NameReasonCodeId)
                    .HasName("NAME_REASON_CODE_DESCRIPTION_UC1")
                    .IsUnique();

                entity.Property(e => e.NameReasonCodeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<NameSearchListItem>(entity =>
            {
                entity.HasIndex(e => e.NameSearchStatusCodeId)
                    .HasName("I_FK_NAME_SEARCH_LIST_ITEM_NAME_SEARCH_STATUS_CODE_ID");

                entity.HasIndex(e => e.ReferenceTitleEventId)
                    .HasName("IX_TITLE_EVNTNM_SRCH_LSTITM_REFTITLE");

                entity.HasIndex(e => new { e.LegalEntityNameId, e.ChainOfTitleId, e.ReferenceTitleEventId })
                    .HasName("I_NAME_SEARCH_LIST_ITEM_ID_LOOKUP");

                entity.HasOne(d => d.LegalEntityName)
                    .WithMany(p => p.NameSearchListItem)
                    .HasForeignKey(d => d.LegalEntityNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LEGAL_ENTITY_NAME");

                entity.HasOne(d => d.NameSearchStatusCode)
                    .WithMany(p => p.NameSearchListItem)
                    .HasForeignKey(d => d.NameSearchStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NAME_SEARCH_STATUS_CODE");

                entity.HasOne(d => d.ReferenceTitleEvent)
                    .WithMany(p => p.NameSearchListItem)
                    .HasForeignKey(d => d.ReferenceTitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVTNM_SRCH_LSTITM_REFTITLE");
            });

            modelBuilder.Entity<NameSearchListReasonCode>(entity =>
            {
                entity.HasKey(e => new { e.NameSearchListItemId, e.NameReasonCodeId });

                entity.HasIndex(e => e.NameReasonCodeId)
                    .HasName("I_FK_NAME_SEARCH_LIST_REASON_CODE_NAME_REASON_CODE_ID");

                entity.HasOne(d => d.NameReasonCode)
                    .WithMany(p => p.NameSearchListReasonCode)
                    .HasForeignKey(d => d.NameReasonCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NAME_SEARCH_LIST_REASON_CODE_NAME_REASON_CODE");

                entity.HasOne(d => d.NameSearchListItem)
                    .WithMany(p => p.NameSearchListReasonCode)
                    .HasForeignKey(d => d.NameSearchListItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NAME_SEARCH_LIST_REASON_CODE_NAME_SEARCH_LIST_ITEM ");
            });

            modelBuilder.Entity<NameSearchParameters>(entity =>
            {
                entity.HasIndex(e => e.LegalEntityNameId)
                    .HasName("I_FK_LEGAL_ENTITY");

                entity.HasIndex(e => e.OwnerBuyerRelationshipId)
                    .HasName("I_FK_NAME_SEARCH_PARAMETERS_OWNER_BUYER_RELATIONSHIP_ID");

                entity.Property(e => e.SearchId).ValueGeneratedNever();

                entity.Property(e => e.LegalFilter).IsUnicode(false);

                entity.HasOne(d => d.LegalEntityName)
                    .WithMany(p => p.NameSearchParameters)
                    .HasForeignKey(d => d.LegalEntityNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LEGAL_ENT_NAME_NAME_SRCH");

                entity.HasOne(d => d.OwnerBuyerRelationship)
                    .WithMany(p => p.NameSearchParameters)
                    .HasForeignKey(d => d.OwnerBuyerRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OWNER_BUYER");

                entity.HasOne(d => d.Search)
                    .WithOne(p => p.NameSearchParameters)
                    .HasForeignKey<NameSearchParameters>(d => d.SearchId)
                    .HasConstraintName("FK_SEARCH_NAME_SRCH_PARMS");
            });

            modelBuilder.Entity<NameSearchStatusCode>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("NAME_SEARCH_STATUS_CODE_DESCRIPTION_UC1")
                    .IsUnique();

                entity.Property(e => e.NameSearchStatusCodeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<OfficialRecordDocument>(entity =>
            {
                entity.HasIndex(e => e.GeographicLocaleId)
                    .HasName("I_FK_GEOGRAPHIC_LOCALE_ID");

                entity.HasOne(d => d.GeographicLocale)
                    .WithMany(p => p.OfficialRecordDocument)
                    .HasForeignKey(d => d.GeographicLocaleId)
                    .HasConstraintName("FK_GEO_LOCALE_ORD");
            });

            modelBuilder.Entity<OrDocumentInformation>(entity =>
            {
                entity.HasIndex(e => e.TypeOfInstrumentId)
                    .HasName("I_FK_TYPE_OF_INSTRUMENT");

                entity.Property(e => e.OfficialRecordDocumentId).ValueGeneratedNever();

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Md5CriticalItemsHash).IsUnicode(false);

                entity.Property(e => e.ScrivnerName).IsUnicode(false);

                entity.Property(e => e.ToiAdditionalInformation).IsUnicode(false);

                entity.Property(e => e.UnparsedLegalDescription).IsUnicode(false);

                entity.Property(e => e.UnparsedRelatedReference).IsUnicode(false);

                entity.HasOne(d => d.OfficialRecordDocument)
                    .WithOne(p => p.OrDocumentInformation)
                    .HasForeignKey<OrDocumentInformation>(d => d.OfficialRecordDocumentId)
                    .HasConstraintName("FK_ORD_ORD_INFORMATION");

                entity.HasOne(d => d.TypeOfInstrument)
                    .WithMany(p => p.OrDocumentInformation)
                    .HasForeignKey(d => d.TypeOfInstrumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPE_OF_INSTRUMENT_ORD");
            });

            modelBuilder.Entity<OwnerBuyerRelationship>(entity =>
            {
                entity.Property(e => e.OwnerBuyerRelationshipId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.HasIndex(e => e.PartyRoleTypeId)
                    .HasName("I_FK_PARTY_ROLE_TYPE");

                entity.Property(e => e.UnparsedParty).IsUnicode(false);

                entity.HasOne(d => d.PartyRoleType)
                    .WithMany(p => p.Party)
                    .HasForeignKey(d => d.PartyRoleTypeId)
                    .HasConstraintName("FK_PARTY_ROLETYPE_PARTY");
            });

            modelBuilder.Entity<PartyLegalEntityName>(entity =>
            {
                entity.HasKey(e => new { e.PartyId, e.LegalEntityNameId });

                entity.HasIndex(e => e.LegalEntityNameId)
                    .HasName("I_FK_PARTY_LEGAL_ENTITY_NAME_LEGAL_ENTITY_NAME_ID");

                entity.HasOne(d => d.LegalEntityName)
                    .WithMany(p => p.PartyLegalEntityName)
                    .HasForeignKey(d => d.LegalEntityNameId)
                    .HasConstraintName("FK_LGL_ENTNM_PARTY_LGL_ENTNM");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.PartyLegalEntityName)
                    .HasForeignKey(d => d.PartyId)
                    .HasConstraintName("FK_PARTY_PARTY_LGL_ENT_NAME");
            });

            modelBuilder.Entity<PartyRoleType>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("IX_PARTY_DESC");

                entity.Property(e => e.PartyRoleTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<PersonalLegalEntityName>(entity =>
            {
                entity.Property(e => e.LegalEntityNameId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Lineage).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.Property(e => e.Prefix).IsUnicode(false);

                entity.Property(e => e.Suffix).IsUnicode(false);

                entity.HasOne(d => d.LegalEntityName)
                    .WithOne(p => p.PersonalLegalEntityName)
                    .HasForeignKey<PersonalLegalEntityName>(d => d.LegalEntityNameId)
                    .HasConstraintName("FK_LGL_ENTNM_PERS_LGL_ENTNM");
            });

            modelBuilder.Entity<PlatProperties>(entity =>
            {
                entity.Property(e => e.PlatReferenceId).ValueGeneratedNever();

                entity.Property(e => e.AlternateHierarchy1).IsUnicode(false);

                entity.Property(e => e.AlternateHierarchy2).IsUnicode(false);

                entity.Property(e => e.PlatName).IsUnicode(false);

                entity.Property(e => e.PrimaryHierarchy).IsUnicode(false);

                entity.HasOne(d => d.PlatReference)
                    .WithOne(p => p.PlatProperties)
                    .HasForeignKey<PlatProperties>(d => d.PlatReferenceId)
                    .HasConstraintName("FK_PLAT_REFERENCE_PROPERTIES");
            });

            modelBuilder.Entity<PlatReference>(entity =>
            {
                entity.Property(e => e.Book).IsUnicode(false);

                entity.Property(e => e.BookSuffix).IsUnicode(false);

                entity.Property(e => e.Page).IsUnicode(false);

                entity.Property(e => e.PageSuffix).IsUnicode(false);

                entity.Property(e => e.Source).IsUnicode(false);
            });

            modelBuilder.Entity<PlattedLegal>(entity =>
            {
                entity.HasKey(e => new { e.PlatReferenceId, e.SubdivisionLevelId });

                entity.HasIndex(e => e.SubdivisionLevelId)
                    .HasName("I_FK_PLATTED_LEGAL_SUBDIVISION_LEVEL_ID");

                entity.HasOne(d => d.PlatReference)
                    .WithMany(p => p.PlattedLegal)
                    .HasForeignKey(d => d.PlatReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLAT_REFERENCE_PLATTD_LEGAL");

                entity.HasOne(d => d.SubdivisionLevel)
                    .WithMany(p => p.PlattedLegal)
                    .HasForeignKey(d => d.SubdivisionLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUBDIV_LEVELS_PLATTED_LEGAL");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasIndex(e => e.PolicyRestrictionTypeId)
                    .HasName("I_FK_POLICY_POLICY_RESTRICTION_TYPE_ID");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MemberNumber).IsUnicode(false);

                entity.Property(e => e.PolicyType).IsUnicode(false);

                entity.HasOne(d => d.PolicyRestrictionType)
                    .WithMany(p => p.Policy)
                    .HasForeignKey(d => d.PolicyRestrictionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_POLICY_RESTRICTION_TYPE");
            });

            modelBuilder.Entity<PolicyGovtLotLegalMql>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.GovernmentLotId, e.UnplattedReferenceId })
                    .HasName("PK_POLICY_GOVT_LOT_LEGAL");

                entity.HasIndex(e => e.GovernmentLotId)
                    .HasName("I_FK_POLICY_GOVT_LOT_LEGAL_MQL_GOVERNMENT_LOT_ID");

                entity.HasIndex(e => e.UnplattedReferenceId)
                    .HasName("I_FK_POLICY_GOVT_LOT_LEGAL_MQL_UNPLATTED_REFERENCE_ID");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyGovtLotLegalMql)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_GOVT_LOT_LEGAL");

                entity.HasOne(d => d.GovernmentLotLegal)
                    .WithMany(p => p.PolicyGovtLotLegalMql)
                    .HasForeignKey(d => new { d.UnplattedReferenceId, d.GovernmentLotId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GOVT_LOT_LEGAL_POLICY");
            });

            modelBuilder.Entity<PolicyInsuredDocument>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.GeographicLocaleId });

                entity.HasIndex(e => e.GeographicLocaleId)
                    .HasName("IX_FKPOLICY_INSURED_DOCUMENT_GEOGRAPHIC_LOCALE_ID");

                entity.Property(e => e.UnparsedInsuredDocument).IsUnicode(false);

                entity.HasOne(d => d.GeographicLocale)
                    .WithMany(p => p.PolicyInsuredDocument)
                    .HasForeignKey(d => d.GeographicLocaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOCATION_POLICY_INSURED_DOCUMENT");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyInsuredDocument)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_POLICY_INSURED_DOCUMENT");
            });

            modelBuilder.Entity<PolicyNotes>(entity =>
            {
                entity.HasIndex(e => e.PolicyId)
                    .HasName("I_FK_POLICY_NOTES_POLICY_ID");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyNotes)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_POLICY_NOTES");
            });

            modelBuilder.Entity<PolicyOrder>(entity =>
            {
                entity.Property(e => e.TrackingIdentifier).IsUnicode(false);
            });

            modelBuilder.Entity<PolicyOrderTracking>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.PolicyOrderId, e.DeliveryOrderInfoId });

                entity.HasIndex(e => e.PolicyOrderId)
                    .HasName("IX_FKPOLICY_ORDER_TRACKING_POLICY_ORDER_ID");

                entity.HasOne(d => d.DeliveryOrderInfo)
                    .WithMany(p => p.PolicyOrderTracking)
                    .HasForeignKey(d => d.DeliveryOrderInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_ORDER_TRACKING_DELIVERY_ORDER_INFO");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyOrderTracking)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_POLICY_ORDER_TRACKING");

                entity.HasOne(d => d.PolicyOrder)
                    .WithMany(p => p.PolicyOrderTracking)
                    .HasForeignKey(d => d.PolicyOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_ORDER_POLICY_ORDER_TRACKING");
            });

            modelBuilder.Entity<PolicyPlattedLegalMql>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.PlatReferenceId, e.SubdivisionLevelId })
                    .HasName("PK_POLICY_PLATTED_LEGAL");

                entity.HasIndex(e => e.PlatReferenceId)
                    .HasName("I_FK_POLICY_PLATTED_LEGAL_MQL_PLAT_REFERENCE_ID");

                entity.HasIndex(e => e.SubdivisionLevelId)
                    .HasName("I_FK_POLICY_PLATTED_LEGAL_MQL_SUBDIVISION_LEVEL_ID");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyPlattedLegalMql)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_PLATTED_LEGAL");

                entity.HasOne(d => d.PlattedLegal)
                    .WithMany(p => p.PolicyPlattedLegalMql)
                    .HasForeignKey(d => new { d.PlatReferenceId, d.SubdivisionLevelId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLATTED_LEGAL_POLICY");
            });

            modelBuilder.Entity<PolicyRestrictionType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<PolicySearch>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.SearchId });

                entity.HasIndex(e => e.SearchId)
                    .HasName("I_FK_POLICY_SEARCH_SEARCH_ID");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicySearch)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_POLICY_SEARCH");

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.PolicySearch)
                    .HasForeignKey(d => d.SearchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEARCH_POLICY_SEARCH");
            });

            modelBuilder.Entity<PolicySectionLegalMql>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.UnplattedReferenceId, e.SectionBreakdownCodeId })
                    .HasName("PK_POLICY_SECTION_LEGAL");

                entity.HasIndex(e => e.SectionBreakdownCodeId)
                    .HasName("I_FK_POLICY_SECTION_LEGAL_MQL_SECTION_BREAKDOWN_CODE_ID");

                entity.HasIndex(e => e.UnplattedReferenceId)
                    .HasName("I_FK_POLICY_SECTION_LEGAL_MQL_UNPLATTED_REFERENCE_ID");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicySectionLegalMql)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_SECTION_LEGAL");

                entity.HasOne(d => d.SectionLegal)
                    .WithMany(p => p.PolicySectionLegalMql)
                    .HasForeignKey(d => new { d.SectionBreakdownCodeId, d.UnplattedReferenceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECT_LEGAL_POLICY_SECTLEGAL");
            });

            modelBuilder.Entity<PolicyTitleStatusReport>(entity =>
            {
                entity.Property(e => e.SearchId).ValueGeneratedNever();

                entity.Property(e => e.TitleStatusReportCode).IsUnicode(false);

                entity.Property(e => e.TitleStatusReportNumber).IsUnicode(false);

                entity.HasOne(d => d.Search)
                    .WithOne(p => p.PolicyTitleStatusReport)
                    .HasForeignKey<PolicyTitleStatusReport>(d => d.SearchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEARCH_POLICY_TSR");
            });

            modelBuilder.Entity<PolicyWorksheetItem>(entity =>
            {
                entity.HasKey(e => new { e.PolicyId, e.WorksheetId });

                entity.HasIndex(e => e.WorksheetId)
                    .HasName("IX_FKPOLICY_WORKSHEET_ITEM_WORKSHEET_ID");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyWorksheetItem)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POLICY_POLICY_WORKSHEET_ITEM");

                entity.HasOne(d => d.Worksheet)
                    .WithMany(p => p.PolicyWorksheetItem)
                    .HasForeignKey(d => d.WorksheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKSHEET_POLICY_WORKSHEET_ITEM");
            });

            modelBuilder.Entity<PropertyAddress>(entity =>
            {
                entity.Property(e => e.OfficialRecordDocumentId).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).IsUnicode(false);

                entity.Property(e => e.AddressLine2).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PostalCode).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.UnparsedAddress).IsUnicode(false);

                entity.HasOne(d => d.OfficialRecordDocument)
                    .WithOne(p => p.PropertyAddress)
                    .HasForeignKey<PropertyAddress>(d => d.OfficialRecordDocumentId)
                    .HasConstraintName("FK_ORD_PROPERTY_ADDRESS");
            });

            modelBuilder.Entity<RangeDirectionType>(entity =>
            {
                entity.Property(e => e.RangeDirectionTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<RelatedCaseNumber>(entity =>
            {
                entity.HasKey(e => new { e.OfficialRecordDocumentId, e.CaseNumberReferenceId });

                entity.HasIndex(e => e.CaseNumberReferenceId)
                    .HasName("I_FK_RELATED_CASE_NUMBER_CASE_NUMBER_REFERENCE_ID");

                entity.HasOne(d => d.CaseNumberReference)
                    .WithMany(p => p.RelatedCaseNumber)
                    .HasForeignKey(d => d.CaseNumberReferenceId)
                    .HasConstraintName("FK_CASE_NBR_REF_RELATED_CASENM");

                entity.HasOne(d => d.OfficialRecordDocument)
                    .WithMany(p => p.RelatedCaseNumber)
                    .HasForeignKey(d => d.OfficialRecordDocumentId)
                    .HasConstraintName("FK_ORD_RELATED_CASE_NBR_REF");
            });

            modelBuilder.Entity<RelatedOrDocument>(entity =>
            {
                entity.HasKey(e => new { e.SearchedOrDocumentId, e.RelatedOrDocumentId });

                entity.HasIndex(e => e.RelatedOrDocumentId)
                    .HasName("I_FK_RELATED_OR_DOCUMENT_RELATED_OR_DOCUMENT_ID");

                entity.HasOne(d => d.RelatedOrDocumentNavigation)
                    .WithMany(p => p.RelatedOrDocumentRelatedOrDocumentNavigation)
                    .HasForeignKey(d => d.RelatedOrDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORD_ID_RELATED_ORD_ID");

                entity.HasOne(d => d.SearchedOrDocument)
                    .WithMany(p => p.RelatedOrDocumentSearchedOrDocument)
                    .HasForeignKey(d => d.SearchedOrDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORD_RELATED_ORD_SEARCHED");
            });

            modelBuilder.Entity<RelatedTaxFolio>(entity =>
            {
                entity.HasKey(e => new { e.OfficialRecordDocumentId, e.TaxFolioReferenceId });

                entity.HasIndex(e => e.TaxFolioReferenceId)
                    .HasName("I_FK_RELATED_TAX_FOLIO_TAX_FOLIO_REFERENCE_ID");

                entity.HasOne(d => d.OfficialRecordDocument)
                    .WithMany(p => p.RelatedTaxFolio)
                    .HasForeignKey(d => d.OfficialRecordDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORD_RELATED_TAX_FOLIO");

                entity.HasOne(d => d.TaxFolioReference)
                    .WithMany(p => p.RelatedTaxFolio)
                    .HasForeignKey(d => d.TaxFolioReferenceId)
                    .HasConstraintName("FK_TAX_FOLIO_REF_RELATED_ID");
            });

            modelBuilder.Entity<Search>(entity =>
            {
                entity.HasIndex(e => e.FileReferenceId)
                    .HasName("I_FILE_REFERENCE_ID");

                entity.HasIndex(e => e.GeographicLocaleId)
                    .HasName("I_FK_GEO_LOCALE");

                entity.HasIndex(e => e.GiCertRangeId)
                    .HasName("I_FK_SEARCH_GI_CERT_RANGE_ID");

                entity.HasIndex(e => e.GrantorCertRangeId)
                    .HasName("I_FK_GRANTOR_CERT_RANGE");

                entity.HasIndex(e => e.ParentSearchId)
                    .HasName("IX_SEARCH_PARENTID");

                entity.HasIndex(e => e.SearchStatusId)
                    .HasName("I_FK_SEARCH_STATUS_ID");

                entity.HasIndex(e => e.SearchTypeId)
                    .HasName("I_FK_SEARCH_TYPE");

                entity.HasIndex(e => new { e.GeographicCertRangeId, e.GiCertRangeId })
                    .HasName("I_FK_GI_CERT_RANGE_ID");

                entity.Property(e => e.InstrumentFilters).IsUnicode(false);

                entity.Property(e => e.SearchReference).IsUnicode(false);

                entity.Property(e => e.SearchStatusId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.FileReference)
                    .WithMany(p => p.Search)
                    .HasForeignKey(d => d.FileReferenceId)
                    .HasConstraintName("FK_FILE_REFERENCE_SEARCH");

                entity.HasOne(d => d.GeographicCertRange)
                    .WithMany(p => p.SearchGeographicCertRange)
                    .HasForeignKey(d => d.GeographicCertRangeId)
                    .HasConstraintName("FK_SEARCH_CERTIFICATION_RANGE");

                entity.HasOne(d => d.GeographicLocale)
                    .WithMany(p => p.Search)
                    .HasForeignKey(d => d.GeographicLocaleId)
                    .HasConstraintName("FK_LOCATION_SEARCH");

                entity.HasOne(d => d.GiCertRange)
                    .WithMany(p => p.SearchGiCertRange)
                    .HasForeignKey(d => d.GiCertRangeId)
                    .HasConstraintName("FK_SEARCH_CERTIFICATION_RANGE1");

                entity.HasOne(d => d.GrantorCertRange)
                    .WithMany(p => p.SearchGrantorCertRange)
                    .HasForeignKey(d => d.GrantorCertRangeId)
                    .HasConstraintName("FK_GRANTOR_CERT_RANGE_SEARCH");

                entity.HasOne(d => d.ParentSearch)
                    .WithMany(p => p.InverseParentSearch)
                    .HasForeignKey(d => d.ParentSearchId)
                    .HasConstraintName("FK_SEARCH_ID_PARENT_SEARCH_ID");

                entity.HasOne(d => d.SearchStatus)
                    .WithMany(p => p.Search)
                    .HasForeignKey(d => d.SearchStatusId)
                    .HasConstraintName("FK_SEARCH_SEARCH_STATUS");

                entity.HasOne(d => d.SearchType)
                    .WithMany(p => p.Search)
                    .HasForeignKey(d => d.SearchTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEARCH_TYPE_SEARCH");
            });

            modelBuilder.Entity<SearchNotes>(entity =>
            {
                entity.HasIndex(e => e.SearchId)
                    .HasName("I_FK_SEARCH");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.SearchNotes)
                    .HasForeignKey(d => d.SearchId)
                    .HasConstraintName("FK_SEARCH_SEARCH_NOTES");
            });

            modelBuilder.Entity<SearchStatus>(entity =>
            {
                entity.Property(e => e.SearchStatusId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<SearchType>(entity =>
            {
                entity.Property(e => e.SearchTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<SearchWarning>(entity =>
            {
                entity.HasIndex(e => e.SearchId)
                    .HasName("I_FK_SEARCH");

                entity.HasIndex(e => e.SearchWarningTypeId)
                    .HasName("I_FK_SEARCH_WARNING_TYPE");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UnparsedSearchWarning).IsUnicode(false);

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.SearchWarning)
                    .HasForeignKey(d => d.SearchId)
                    .HasConstraintName("FK_SEARCH_SEARCH_WARNING");

                entity.HasOne(d => d.SearchWarningType)
                    .WithMany(p => p.SearchWarning)
                    .HasForeignKey(d => d.SearchWarningTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SRCH_WARN_TYPE_SRCH_WARNING");
            });

            modelBuilder.Entity<SearchWarningHelp>(entity =>
            {
                entity.Property(e => e.SearchWarningTypeId).ValueGeneratedNever();

                entity.Property(e => e.HelpText).IsUnicode(false);

                entity.HasOne(d => d.SearchWarningType)
                    .WithOne(p => p.SearchWarningHelp)
                    .HasForeignKey<SearchWarningHelp>(d => d.SearchWarningTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SEARCH_WARNING_HELP_SEARCH_WARNING_TYPE");
            });

            modelBuilder.Entity<SearchWarningType>(entity =>
            {
                entity.Property(e => e.SearchWarningTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<SectionBreakdownCode>(entity =>
            {
                entity.HasIndex(e => new { e.SectionQuarter, e.Section16th, e.Section64th, e.Section256th, e.SectionBreakdownCodeId })
                    .HasName("IX_SECTION_BREAKDOWN");
            });

            modelBuilder.Entity<SectionLegal>(entity =>
            {
                entity.HasKey(e => new { e.SectionBreakdownCodeId, e.UnplattedReferenceId });

                entity.HasIndex(e => e.UnplattedReferenceId)
                    .HasName("I_FK_SECTION_LEGAL_UNPLATTED_REFERENCE_ID");

                entity.HasOne(d => d.SectionBreakdownCode)
                    .WithMany(p => p.SectionLegal)
                    .HasForeignKey(d => d.SectionBreakdownCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECT_BRKDWN_CD_SECT_LEGAL");

                entity.HasOne(d => d.UnplattedReference)
                    .WithMany(p => p.SectionLegal)
                    .HasForeignKey(d => d.UnplattedReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UNPLATTED_REF_SECT_LEGAL");
            });

            modelBuilder.Entity<SubdivisionLevels>(entity =>
            {
                entity.HasIndex(e => new { e.Level1, e.Level2, e.Level3 })
                    .HasName("SUBDIVISION_LEVELS_UC1")
                    .IsUnique();

                entity.Property(e => e.Level1).IsUnicode(false);

                entity.Property(e => e.Level2).IsUnicode(false);

                entity.Property(e => e.Level3).IsUnicode(false);
            });

            modelBuilder.Entity<SubdivisionPlattedLegal>(entity =>
            {
                entity.HasKey(e => new { e.SearchId, e.PlatReferenceId, e.SubdivisionLevelId });

                entity.HasIndex(e => e.PlatReferenceId)
                    .HasName("IX_SBDV_PLT_LGL_PLT_REF_ID");

                entity.HasIndex(e => e.SearchId)
                    .HasName("IX_SBDV_PLT_LGL_SBDV_SRCH_ID");

                entity.HasIndex(e => e.SubdivisionLevelId)
                    .HasName("IX_SBDV_PLT_LGL_SBDV_LVL_ID");

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.SubdivisionPlattedLegal)
                    .HasForeignKey(d => d.SearchId)
                    .HasConstraintName("FK_SUBD_PLATTED_LGL_SRCH");

                entity.HasOne(d => d.PlattedLegal)
                    .WithMany(p => p.SubdivisionPlattedLegal)
                    .HasForeignKey(d => new { d.PlatReferenceId, d.SubdivisionLevelId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SBDV_PLT_LGL_PLT_LGL");
            });

            modelBuilder.Entity<TaxFolioReference>(entity =>
            {
                entity.HasIndex(e => e.GeographicLocaleId)
                    .HasName("I_FK_GEOGRAPHIC_LOCALE");

                entity.HasIndex(e => new { e.FolioNumber, e.GeographicLocaleId })
                    .HasName("TAX_FOLIO_REFERENCE_UC1")
                    .IsUnique();

                entity.Property(e => e.FolioNumber).IsUnicode(false);

                entity.HasOne(d => d.GeographicLocale)
                    .WithMany(p => p.TaxFolioReference)
                    .HasForeignKey(d => d.GeographicLocaleId)
                    .HasConstraintName("FK_GEO_LOCALE_TAX_FOLIO_REF");
            });

            modelBuilder.Entity<TitleEvent>(entity =>
            {
                entity.HasIndex(e => e.CurrentExamStatusTypeId)
                    .HasName("I_CURRENT_EXAM_STATUS_TYPE");

                entity.HasIndex(e => e.OriginalExamStatusTypeId)
                    .HasName("I_ORIGINAL_EXAM_STATUS");

                entity.HasIndex(e => e.TitleEventStatusAssignorId)
                    .HasName("I_TITLE_EVT_STAT_ASSIGNOR");

                entity.HasIndex(e => e.TitleEventTypeId)
                    .HasName("I_EVENT_TYPE");

                entity.Property(e => e.AdditionalInformation).IsUnicode(false);

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tag).IsUnicode(false);

                entity.HasOne(d => d.CurrentExamStatusType)
                    .WithMany(p => p.TitleEventCurrentExamStatusType)
                    .HasForeignKey(d => d.CurrentExamStatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAM_STAT_TYPE_TITLEVNT_CUR");

                entity.HasOne(d => d.OriginalExamStatusType)
                    .WithMany(p => p.TitleEventOriginalExamStatusType)
                    .HasForeignKey(d => d.OriginalExamStatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXAM_STAT_TYPE_TITLEVNT_ORI");

                entity.HasOne(d => d.TitleEventStatusAssignor)
                    .WithMany(p => p.TitleEvent)
                    .HasForeignKey(d => d.TitleEventStatusAssignorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_STATUS_ASSIGNOR");

                entity.HasOne(d => d.TitleEventType)
                    .WithMany(p => p.TitleEvent)
                    .HasForeignKey(d => d.TitleEventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_TITLE_EVENT_TYP");
            });

            modelBuilder.Entity<TitleEventDocument>(entity =>
            {
                entity.HasKey(e => new { e.TitleEventId, e.OfficialRecordDocumentId });

                entity.HasIndex(e => e.OfficialRecordDocumentId)
                    .HasName("I_TITLE_EVENT_DOCUMENT_OFF_REC_DOC_ID");

                entity.HasIndex(e => e.TitleEventId)
                    .HasName("UC_TITLE_EVENT_DOCUMENT")
                    .IsUnique();

                entity.HasOne(d => d.OfficialRecordDocument)
                    .WithMany(p => p.TitleEventDocument)
                    .HasForeignKey(d => d.OfficialRecordDocumentId)
                    .HasConstraintName("FK_ORD_TITLE_EVENT");

                entity.HasOne(d => d.TitleEvent)
                    .WithOne(p => p.TitleEventDocument)
                    .HasForeignKey<TitleEventDocument>(d => d.TitleEventId)
                    .HasConstraintName("FK_TITLE_EVENT_DOCUMENTS");
            });

            modelBuilder.Entity<TitleEventGovtLotLegalMql>(entity =>
            {
                entity.HasKey(e => new { e.UnplattedReferenceId, e.GovernmentLotId, e.TitleEventId })
                    .HasName("PK_TITLE_EVENT_GOVT_LOT_LEGAL");

                entity.HasIndex(e => e.GovernmentLotId)
                    .HasName("I_FK_TITLE_EVENT_GOVT_LOT_LEGAL_MQL_GOVERNMENT_LOT_ID");

                entity.HasIndex(e => e.TitleEventId);

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventGovtLotLegalMql)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_GOVT_LOT_LEGAL");

                entity.HasOne(d => d.GovernmentLotLegal)
                    .WithMany(p => p.TitleEventGovtLotLegalMql)
                    .HasForeignKey(d => new { d.UnplattedReferenceId, d.GovernmentLotId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GOVT_LOT_LEGAL_TITLE_EVENT");
            });

            modelBuilder.Entity<TitleEventLegalEntityMql>(entity =>
            {
                entity.HasKey(e => new { e.TitleEventId, e.LegalEntityNameId })
                    .HasName("PK_TITLE_EVENT_LEGAL_ENTITY");

                entity.HasIndex(e => e.LegalEntityNameId)
                    .HasName("I_FK_TITLE_EVENT_LEGAL_ENTITY_MQL_LEGAL_ENTITY_NAME_ID");

                entity.HasOne(d => d.LegalEntityName)
                    .WithMany(p => p.TitleEventLegalEntityMql)
                    .HasForeignKey(d => d.LegalEntityNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LEGAL_ENTNM_TITLEVT_LGL_ENT");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventLegalEntityMql)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_LEGAL_ENTITY");
            });

            modelBuilder.Entity<TitleEventNotes>(entity =>
            {
                entity.HasIndex(e => e.TitleEventId)
                    .HasName("I_TITLE_EVENT");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventNotes)
                    .HasForeignKey(d => d.TitleEventId)
                    .HasConstraintName("FK_TITLE_EVENT_NOTES");
            });

            modelBuilder.Entity<TitleEventOrder>(entity =>
            {
                entity.HasIndex(e => e.TrackingIdentifier);

                entity.Property(e => e.TrackingIdentifier).IsUnicode(false);
            });

            modelBuilder.Entity<TitleEventOrderTracking>(entity =>
            {
                entity.HasKey(e => new { e.TitleEventId, e.TitleEventOrderId, e.DeliveryOrderInfoId });

                entity.HasIndex(e => e.TitleEventOrderId)
                    .HasName("IX_FKTITLE_EVENT_ORDER_TRACKING_TITLE_EVENT_ORDER_ID");

                entity.HasOne(d => d.DeliveryOrderInfo)
                    .WithMany(p => p.TitleEventOrderTracking)
                    .HasForeignKey(d => d.DeliveryOrderInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_ORDER_TRACKING_DELIVERY_ORDER_INFO");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventOrderTracking)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TE_TE_ORDER_TRACKING");

                entity.HasOne(d => d.TitleEventOrder)
                    .WithMany(p => p.TitleEventOrderTracking)
                    .HasForeignKey(d => d.TitleEventOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TE_ORDER_TE_ORDER_TRACKING");
            });

            modelBuilder.Entity<TitleEventParty>(entity =>
            {
                entity.HasKey(e => new { e.TitleEventId, e.PartyId });

                entity.HasIndex(e => e.PartyId)
                    .HasName("I_FK_TITLE_EVENT_PARTY_PARTY_ID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TitleEventParty)
                    .HasForeignKey(d => d.PartyId)
                    .HasConstraintName("FK_PARTY_TITLE_EVENT_PARTY");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventParty)
                    .HasForeignKey(d => d.TitleEventId)
                    .HasConstraintName("FK_TITLE_EVENT_PARTY");
            });

            modelBuilder.Entity<TitleEventPlattedLegalMql>(entity =>
            {
                entity.HasKey(e => new { e.SubdivisionLevelId, e.PlatReferenceId, e.TitleEventId })
                    .HasName("PK_TITLE_EVENT_PLATTED_LEGAL");

                entity.HasIndex(e => e.PlatReferenceId)
                    .HasName("I_FK_TITLE_EVENT_PLATTED_LEGAL_MQL_PLAT_REFERENCE_ID");

                entity.HasIndex(e => e.TitleEventId);

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventPlattedLegalMql)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_PLATTED_LEGAL");

                entity.HasOne(d => d.PlattedLegal)
                    .WithMany(p => p.TitleEventPlattedLegalMql)
                    .HasForeignKey(d => new { d.PlatReferenceId, d.SubdivisionLevelId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PLATTED_LEGAL_TITLE_EVENT");
            });

            modelBuilder.Entity<TitleEventSearch>(entity =>
            {
                entity.HasKey(e => new { e.TitleEventId, e.SearchId });

                entity.HasIndex(e => new { e.SearchId, e.TitleEventId })
                    .HasName("IX_SEARCH_ID_TITLE_EVENT_ID");

                entity.HasOne(d => d.Search)
                    .WithMany(p => p.TitleEventSearch)
                    .HasForeignKey(d => d.SearchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_SEARCH_ID");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventSearch)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_TITLE_EVENT_ID");
            });

            modelBuilder.Entity<TitleEventSectionLegalMql>(entity =>
            {
                entity.HasKey(e => new { e.SectionBreakdownCodeId, e.UnplattedReferenceId, e.TitleEventId })
                    .HasName("PK_TITLE_EVENT_SECTION_LEGAL");

                entity.HasIndex(e => e.TitleEventId);

                entity.HasIndex(e => e.UnplattedReferenceId)
                    .HasName("I_FK_TITLE_EVENT_SECTION_LEGAL_MQL_UNPLATTED_REFERENCE_ID");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleEventSectionLegalMql)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_SECTION_LEGAL");

                entity.HasOne(d => d.SectionLegal)
                    .WithMany(p => p.TitleEventSectionLegalMql)
                    .HasForeignKey(d => new { d.SectionBreakdownCodeId, d.UnplattedReferenceId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECT_LEGAL_TEVENT_SECTLEGAL");
            });

            modelBuilder.Entity<TitleEventStatusAssignor>(entity =>
            {
                entity.Property(e => e.TitleEventStatusAssignorId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<TitleEventType>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("TITLE_EVENT_TYPE_UC1")
                    .IsUnique();

                entity.HasIndex(e => e.EventCategoryId)
                    .HasName("I_EVENT_CATEGORY");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.TitleEventCode).IsUnicode(false);

                entity.HasOne(d => d.EventCategory)
                    .WithMany(p => p.TitleEventType)
                    .HasForeignKey(d => d.EventCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_EVENT_CTGRY_EVTTYPE");
            });

            modelBuilder.Entity<TitleEventTypeCategory>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("TITLE_EVENT_TYPE_CATEGORY_UC1")
                    .IsUnique();

                entity.Property(e => e.TitleEventCategoryId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<TitleSearchOrigination>(entity =>
            {
                entity.HasIndex(e => e.FileReferenceId)
                    .HasName("UX_TITLE_SEARCH_ORIGINATION")
                    .IsUnique();

                entity.HasIndex(e => e.TitleEventId)
                    .HasName("FK_TITLE_SEARCH_ORIGINATION_TITLE_EVENT_ID");

                entity.Property(e => e.OrderReference).IsUnicode(false);

                entity.HasOne(d => d.FileReference)
                    .WithOne(p => p.TitleSearchOrigination)
                    .HasForeignKey<TitleSearchOrigination>(d => d.FileReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_SEARCH_ORIGINATION_FILE_REFERENCE");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.TitleSearchOrigination)
                    .HasForeignKey(d => d.TitleEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TITLE_SEARCH_ORIGINATION_TITLE_EVENT");
            });

            modelBuilder.Entity<TownshipDirectionType>(entity =>
            {
                entity.Property(e => e.TownshipDirectionTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<TypeOfInstrument>(entity =>
            {
                entity.HasIndex(e => e.TypeOfInstrument1)
                    .HasName("TYPE_OF_INSTRUMENT_UC1")
                    .IsUnique();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.TypeOfInstrument1).IsUnicode(false);
            });

            modelBuilder.Entity<UnplattedReference>(entity =>
            {
                entity.HasIndex(e => e.BreakdownCodeTypeId)
                    .HasName("I_FK_BRKDWN_CODE_TYPE");

                entity.HasIndex(e => e.RangeDirectionTypeId)
                    .HasName("I_FK_RANGE_DIRECTION_TYPE");

                entity.HasIndex(e => e.TownshipDirectionTypeId)
                    .HasName("I_FK_TOWNSHIP_DIRECTION");

                entity.HasIndex(e => new { e.Meridian, e.Range, e.RangeDirectionTypeId, e.Township, e.TownshipDirectionTypeId, e.Section, e.UnplattedReferenceId })
                    .HasName("IX_UNPLATTED_REFERENCE_SMQ1");

                entity.Property(e => e.Meridian).IsUnicode(false);

                entity.Property(e => e.Range).IsUnicode(false);

                entity.Property(e => e.Section).IsUnicode(false);

                entity.Property(e => e.Township).IsUnicode(false);

                entity.HasOne(d => d.BreakdownCodeType)
                    .WithMany(p => p.UnplattedReference)
                    .HasForeignKey(d => d.BreakdownCodeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRKDWN_CD_TYPE_UNPLAT_REF");

                entity.HasOne(d => d.RangeDirectionType)
                    .WithMany(p => p.UnplattedReference)
                    .HasForeignKey(d => d.RangeDirectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RNG_DIR_TYPE_UNPLATTED_REF");

                entity.HasOne(d => d.TownshipDirectionType)
                    .WithMany(p => p.UnplattedReference)
                    .HasForeignKey(d => d.TownshipDirectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TWNSHP_DIR_TYPE_UNPLAT_REF");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_CREATED_BY");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.InverseModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_MODIFIED_BY");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => new { e.ProfileId, e.UserId });

                entity.Property(e => e.ProfileId).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserProfileCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROFILE_CREATED_BY_USER");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserProfileModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROFILE_MODIFIED_BY_USER");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfileUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROFILE_USER");
            });

            modelBuilder.Entity<UserProfileFileReference>(entity =>
            {
                entity.HasKey(e => new { e.ProfileId, e.UserId, e.FileReferenceId });

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserProfileFileReferenceCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROFILE_FILE_REFERENCE_CREATED_BY_USER");

                entity.HasOne(d => d.FileReference)
                    .WithMany(p => p.UserProfileFileReference)
                    .HasForeignKey(d => d.FileReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROFILE_FILE_REFERENCE_FILE_REFERENCE");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserProfileFileReferenceModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROFILE_FILE_REFERENCE_MODIFIED_BY_USER");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfileFileReferenceUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROFILE_FILE_REFERENCE_USER");

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.UserProfileFileReference)
                    .HasForeignKey(d => new { d.ProfileId, d.UserId })
                    .HasConstraintName("FK_USER_PROFILE_FILE_REFERENCE_USER_PROFILE");
            });

            modelBuilder.Entity<Worksheet>(entity =>
            {
                entity.HasIndex(e => e.FileReferenceId)
                    .HasName("WORKSHEET_UC1")
                    .IsUnique();

                entity.HasOne(d => d.FileReference)
                    .WithOne(p => p.Worksheet)
                    .HasForeignKey<Worksheet>(d => d.FileReferenceId)
                    .HasConstraintName("FK_FILE_REFERENCE_WKSHEET");
            });

            modelBuilder.Entity<WorksheetItem>(entity =>
            {
                entity.HasKey(e => new { e.TitleEventId, e.WorksheetId });

                entity.HasIndex(e => e.WorksheetId)
                    .HasName("I_FK_WORKSHEET_ITEM_WORKSHEET_ID");

                entity.HasOne(d => d.TitleEvent)
                    .WithMany(p => p.WorksheetItem)
                    .HasForeignKey(d => d.TitleEventId)
                    .HasConstraintName("FK_TITLE_EVENT_WORKSHEET_ITEM");

                entity.HasOne(d => d.Worksheet)
                    .WithMany(p => p.WorksheetItem)
                    .HasForeignKey(d => d.WorksheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKSHEET_WORKSHEET_ITEM");
            });

            modelBuilder.Entity<YearNumberReference>(entity =>
            {
                entity.Property(e => e.OfficialRecordDocumentId).ValueGeneratedNever();

                entity.Property(e => e.SeriesCode).IsUnicode(false);

                entity.Property(e => e.Source).IsUnicode(false);

                entity.Property(e => e.Suffix).IsUnicode(false);

                entity.HasOne(d => d.OfficialRecordDocument)
                    .WithOne(p => p.YearNumberReference)
                    .HasForeignKey<YearNumberReference>(d => d.OfficialRecordDocumentId)
                    .HasConstraintName("FK_ORD_YEAR_NUMBER_REF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}