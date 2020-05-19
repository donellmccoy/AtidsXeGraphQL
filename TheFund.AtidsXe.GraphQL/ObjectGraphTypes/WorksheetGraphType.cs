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
    public sealed class WorksheetGraphType : ObjectGraphTypeBase<Worksheet>
    {
        public WorksheetGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Field(x => x.FileReferenceId);
            Field(x => x.WorksheetId);

            FieldListAsync<WorksheetItemGraphType, WorksheetItem>(
                FieldNames.WorksheetItems,
                p => p.WorksheetId,
                p => p.WorksheetId);

            FieldListAsync<PolicyWorksheetItemGraphType, PolicyWorksheetItem>(
                FieldNames.PolicyWorksheetItems,
                p => p.WorksheetId,
                p => p.WorksheetId);
        }
    }
}