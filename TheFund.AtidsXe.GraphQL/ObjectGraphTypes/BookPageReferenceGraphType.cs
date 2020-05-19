using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class BookPageReferenceGraphType : ObjectGraphTypeBase<BookPageReference>
    {
        public BookPageReferenceGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(BookPageReferenceGraphType);
            Description = nameof(BookPageReferenceGraphType);

            Field(p => p.OfficialRecordDocumentId);
            Field(p => p.Book, true);
            Field(p => p.BookSuffix, true);
            Field(p => p.Page, true);
            Field(p => p.PageSuffix, true);
            FieldListAsync<OfficialRecordDocumentGraphType, OfficialRecordDocument>(
                 FieldNames.OfficialRecordDocuments,
                 p => p.OfficialRecordDocumentId,
                 p => p.OfficialRecordDocumentId);
        }
    }
}