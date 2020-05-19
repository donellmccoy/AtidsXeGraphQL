using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheFund.AtidsXe.Entities.Models
{
    [Table("TITLE_EVENT")]
    public partial class TitleEvent
    {
        public TitleEvent()
        {
            ChainOfTitleItem = new HashSet<ChainOfTitleItem>();
            NameSearchListItem = new HashSet<NameSearchListItem>();
            TitleEventGovtLotLegalMql = new HashSet<TitleEventGovtLotLegalMql>();
            TitleEventLegalEntityMql = new HashSet<TitleEventLegalEntityMql>();
            TitleEventNotes = new HashSet<TitleEventNotes>();
            TitleEventOrderTracking = new HashSet<TitleEventOrderTracking>();
            TitleEventParty = new HashSet<TitleEventParty>();
            TitleEventPlattedLegalMql = new HashSet<TitleEventPlattedLegalMql>();
            TitleEventSearch = new HashSet<TitleEventSearch>();
            TitleEventSectionLegalMql = new HashSet<TitleEventSectionLegalMql>();
            TitleSearchOrigination = new HashSet<TitleSearchOrigination>();
            WorksheetItem = new HashSet<WorksheetItem>();
        }

        [Column("TITLE_EVENT_ID")]
        public int TitleEventId { get; set; }
        [Column("CURRENT_EXAM_STATUS_TYPE_ID")]
        public int CurrentExamStatusTypeId { get; set; }
        [Column("ORIGINAL_EXAM_STATUS_TYPE_ID")]
        public int OriginalExamStatusTypeId { get; set; }
        [Column("TITLE_EVENT_STATUS_ASSIGNOR_ID")]
        public int TitleEventStatusAssignorId { get; set; }
        [Column("TITLE_EVENT_TYPE_ID")]
        public int TitleEventTypeId { get; set; }
        [Column("AMOUNT", TypeName = "numeric(13, 2)")]
        public decimal? Amount { get; set; }
        [Column("ADDITIONAL_INFORMATION")]
        [StringLength(15)]
        public string AdditionalInformation { get; set; }
        [Column("TITLE_EVENT_DATE", TypeName = "datetime")]
        public DateTime? TitleEventDate { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("TAG")]
        [StringLength(50)]
        public string Tag { get; set; }

        [ForeignKey("CurrentExamStatusTypeId")]
        [InverseProperty("TitleEventCurrentExamStatusType")]
        public virtual ExaminationStatusType CurrentExamStatusType { get; set; }
        [ForeignKey("OriginalExamStatusTypeId")]
        [InverseProperty("TitleEventOriginalExamStatusType")]
        public virtual ExaminationStatusType OriginalExamStatusType { get; set; }
        [ForeignKey("TitleEventStatusAssignorId")]
        [InverseProperty("TitleEvent")]
        public virtual TitleEventStatusAssignor TitleEventStatusAssignor { get; set; }
        [ForeignKey("TitleEventTypeId")]
        [InverseProperty("TitleEvent")]
        public virtual TitleEventType TitleEventType { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual MortgageTitleEvent MortgageTitleEvent { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual TitleEventDocument TitleEventDocument { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<ChainOfTitleItem> ChainOfTitleItem { get; set; }
        [InverseProperty("ReferenceTitleEvent")]
        public virtual ICollection<NameSearchListItem> NameSearchListItem { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventGovtLotLegalMql> TitleEventGovtLotLegalMql { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventLegalEntityMql> TitleEventLegalEntityMql { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventNotes> TitleEventNotes { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventOrderTracking> TitleEventOrderTracking { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventParty> TitleEventParty { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventPlattedLegalMql> TitleEventPlattedLegalMql { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventSearch> TitleEventSearch { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleEventSectionLegalMql> TitleEventSectionLegalMql { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<TitleSearchOrigination> TitleSearchOrigination { get; set; }
        [InverseProperty("TitleEvent")]
        public virtual ICollection<WorksheetItem> WorksheetItem { get; set; }
    }
}