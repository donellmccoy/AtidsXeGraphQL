using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class ChainOfTitleGraphType : ObjectGraphTypeBase<ChainOfTitle>
    {
        #region Constuctors

        public ChainOfTitleGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(ChainOfTitleGraphType);
            Description = nameof(ChainOfTitleGraphType);

            Field(p => p.ChainOfTitleId);
            Field(p => p.FileReferenceId);

			FieldListAsync<ChainOfTitleItemGraphType, ChainOfTitleItem>(
                FieldNames.ChainOfTitleItems,
                p => p.ChainOfTitleId,
                p => p.ChainOfTitleId);

			FieldListAsync<ChainOfTitleNotesGraphType, ChainOfTitleNotes>(
                FieldNames.ChainOfTitleNotes,
                p => p.ChainOfTitleId,
                p => p.ChainOfTitleId);

			FieldListAsync<ChainOfTitleSearchGraphType, ChainOfTitleSearch>(
                FieldNames.ChainOfTitleSearches,
                p => p.ChainOfTitleId,
                p => p.ChainOfTitleId);
        }

        #endregion
    }
}