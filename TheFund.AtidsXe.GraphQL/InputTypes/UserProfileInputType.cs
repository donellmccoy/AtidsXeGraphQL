using GraphQL.Types;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.InputTypes
{
    public class UserProfileInputType : InputObjectGraphType<UserProfile>
    {
        public UserProfileInputType()
        {
            Name = "UserProfileInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("description");
        }
    }
}