using GraphQL.Types;

namespace TheFund.AtidsXe.GraphQL.InputTypes
{
    public class TitleEventInputType : InputObjectGraphType
    {
        public TitleEventInputType()
        {
            Name = "TitleEventInput";
            Description = "Title Event";
            DeprecationReason = null;

            Field<NonNullGraphType<IntGraphType>>("TitleEventId");
            Field<NonNullGraphType<IntGraphType>>("CurrentExamStatusTypeId");
            Field<NonNullGraphType<IntGraphType>>("OriginalExamStatusTypeId");
            Field<NonNullGraphType<IntGraphType>>("TitleEventStatusAssignorId");
            Field<NonNullGraphType<IntGraphType>>("TitleEventTypeId");
            Field<DecimalGraphType>("Amount");
            Field<StringGraphType>("AdditionalInformation");
            Field<DateGraphType>("TitleEventDate");
            Field<DateGraphType>("CreateDate");
            Field<StringGraphType>("Tag");
        }
    }
}
