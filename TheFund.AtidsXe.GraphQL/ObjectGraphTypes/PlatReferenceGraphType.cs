using GraphQL.Types;
using System.Collections.Generic;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PlatReferenceGraphType : ObjectGraphTypeBase<PlatReference>
    {
        private readonly IEFDataStore _dataStore;

        public PlatReferenceGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(PlatReferenceGraphType);
            Description = nameof(PlatReferenceGraphType);

            InitializeGraphTypes();
        }

        private void InitializeGraphTypes()
        {
            Field(p => p.PlatReferenceId);
            Field(p => p.Source, true);
            Field(p => p.Book, true);
            Field(p => p.BookSuffix, true);
            Field(p => p.Page, true);
            Field(p => p.PageSuffix, true);
        }
    }
}