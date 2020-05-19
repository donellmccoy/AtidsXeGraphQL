using GraphQL.Types;
using GraphQL.Types.Relay.DataObjects;
using System;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.Extensions;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class FileReferenceGraphType : ObjectGraphTypeBase<FileReference>
    {
        public FileReferenceGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(FileReferenceGraphType);
            Description = nameof(FileReferenceGraphType);

            //Connection<FileReferenceGraphType>().

            Field(p => p.FileReferenceId);
            Field(p => p.BranchLocationId);
            Field(p => p.FileStatusId);
            Field(p => p.FileReference1, true).Name(FieldNames.FileReferenceName);
            Field<StringGraphType>(FieldNames.WorkerId, context => context.Source.WorkerId.TrimIfNotNull());
            Field<DateTimeGraphType>(FieldNames.UpdateDate, context => context.Source.UpdateDate);
            Field<DateTimeGraphType>(FieldNames.CreateDate, context => context.Source.CreateDate);
            Field(p => p.DefaultGeographicLocaleId, true);
            Field<IntGraphType>(FieldNames.IsTemporaryFile, context => context.Source.IsTemporaryFile);

            Func<FileReference, int> predicate = p => p.FileReferenceId;

            Field<BranchLocationGraphType, BranchLocation>(
                FieldNames.BranchLocation,
                fileReference => fileReference.BranchLocationId,
                p => p.BranchLocationId);

            Field<GeographicLocaleGraphType, GeographicLocale>(
                FieldNames.GeographicLocale,
                p => p.DefaultGeographicLocaleId.GetValueOrDefault(),
                p => p.GeographicLocaleId);

            Field<TitleSearchOriginationGraphType, TitleSearchOrigination>(
                FieldNames.TitleSearchOrigination,
                predicate,
                p => p.FileReferenceId);

            Field<WorksheetGraphType, Worksheet>(
                FieldNames.Worksheet,
                predicate,
                p => p.FileReferenceId);

            Field<FileStatusGraphType, FileStatus>(
                FieldNames.FileStatus,
                fileReference => fileReference.FileStatusId,
                p => p.FileStatusId);

            FieldListAsync<ChainOfTitleGraphType, ChainOfTitle>(
                FieldNames.ChainOfTitles,
                predicate,
                p => p.FileReferenceId);

            FieldListAsync<SearchGraphType, Search>(
                FieldNames.Searches,
                predicate,
                p => p.FileReferenceId);

            FieldListAsync<FileReferenceNotesGraphType, FileReferenceNotes>(
                FieldNames.FileReferenceNotes,
                predicate,
                p => p.FileReferenceId);
        }
    }
}