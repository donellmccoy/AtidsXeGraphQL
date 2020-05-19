using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class FileReferenceNotesGraphType : ObjectGraphTypeBase<FileReferenceNotes>
    {
        public FileReferenceNotesGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Field(x => x.FileReferenceId);
            Field(x => x.FileReferenceNotesId);
            Field<StringGraphType>(FieldNames.Message, context => context.Source.Message.TrimIfNotNull());
            Field<StringGraphType>(FieldNames.UserId, context => context.Source.UserId.TrimIfNotNull());
            Field(x => x.TimeStamp);
        }
    }
}