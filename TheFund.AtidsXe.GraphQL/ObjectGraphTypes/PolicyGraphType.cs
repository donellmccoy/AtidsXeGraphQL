using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using TheFund.AtidsXe.Data.Respositories;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class PolicyGraphType : ObjectGraphTypeBase<Policy>
    {
        public PolicyGraphType(IGenericRepository genericRepository) : base(genericRepository)
        {
            Name = nameof(PolicyGraphType);
            Description = nameof(PolicyGraphType);

            Field(p => p.PolicyId);
            Field(p => p.PolicyNumber);
            Field(p => p.PolicyRestrictionTypeId);
            Field(p => p.MemberNumber, true);
            Field(p => p.PolicyType, true);
            Field(p => p.CreateDate);
            Field(p => p.EffectiveDate);
            Field<IntGraphType>(FieldNames.ImageAvailable, context => context.Source.ImageAvailable);
            Field(p => p.InsuredAmount, true);
            Field<DateTimeGraphType>(FieldNames.SystemUpdateDate, context => context.Source.SystemUpdateDate);
            Field<IntGraphType>(FieldNames.TitleBaseIndicator, context => context.Source.TitleBaseIndicator);
            Field(p => p.UserUpdateDate, true);

            //PolicyGovtLotLegalMql
            //PolicyInsuredDocument
            //PolicyNotes
            //PolicyOrderTracking
            //PolicyPlattedLegalMql
            //PolicySearch
            //PolicySectionLegalMql
            //PolicyWorksheetItem
        }
    }
}