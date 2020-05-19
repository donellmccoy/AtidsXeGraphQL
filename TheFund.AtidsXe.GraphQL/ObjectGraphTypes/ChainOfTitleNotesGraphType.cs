using System;
using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class ChainOfTitleNotesGraphType : ObjectGraphType<ChainOfTitleNotes>
    {
        private readonly IEFDataStore _efDataStore;

        public ChainOfTitleNotesGraphType(IEFDataStore efDataStore)
        {
            _efDataStore = efDataStore;

            Name = nameof(ChainOfTitleNotesGraphType);
            Description = nameof(ChainOfTitleNotesGraphType);

            InitializePrimitiveTypes();
            InitializeComplexTypes();
        }

        private void InitializePrimitiveTypes()
        {
            Field(p => p.ChainOfTitleId);
            Field(p => p.ChainOfTitleNotesId);
            Field(p => p.Message, true);
            Field(p => p.UserId, true);
            Field(p => p.TimeStamp);
        }

        private void InitializeComplexTypes()
        {
            
        }
    }
}