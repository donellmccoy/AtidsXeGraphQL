using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.ObjectGraphTypes;

namespace TheFund.AtidsXe.GraphQL.Mutations
{
    public class FileReferenceMutation : ObjectGraphType
    {
        public FileReferenceMutation(IEFDataStore dataStore)
        {
            Field<UserProfileGraphType>
            (
                "deleteProfile",
                arguments: new QueryArguments
                (
                    QueryArgumentFactory.Create<NonNullGraphType<IntGraphType>>("profileId", "Id of user's profile"),
                    QueryArgumentFactory.Create<NonNullGraphType<IntGraphType>>("userId", "Id of user")
                ),
                resolve: context =>
                {
                    var profileId = context.GetArgument<int>("profileId");
                    var userId = context.GetArgument<int>("userId");
                    return dataStore.DeleteEntity<UserProfile>(p => p.UserId == userId && p.ProfileId == profileId);
                }
            );

            //Field<UserProfileInputType>
            //(
            //    "UpdateProfile",
            //    arguments: new QueryArguments
            //    (
            //        new QueryArgument<NonNullGraphType<UserProfileInputType>> { Name = "userprofile" }
            //    ),
            //    resolve: context =>
            //    {
            //        var userProfile = context.GetArgument<UserProfile>("userprofile");
            //        return dataStore.UpdateEntity(userProfile);
            //    }
            //);
        }
    }
}
