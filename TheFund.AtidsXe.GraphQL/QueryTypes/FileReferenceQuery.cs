using GraphQL.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;
using TheFund.AtidsXe.GraphQL.Constants;
using TheFund.AtidsXe.GraphQL.ObjectGraphTypes;
using TheFund.AtidsXe.GraphQL.Properties;

namespace TheFund.AtidsXe.GraphQL.QueryTypes
{
    public sealed class FileReferenceQuery : ObjectGraphType
    {
        public FileReferenceQuery(IEFDataStore dataStore)
        {
            Name = "FileReferenceQuery";
            Description = Resources.File_reference_query;
            DeprecationReason = null;

            #region File References By Name

            FieldAsync<ListGraphType<FileReferenceGraphType>, IEnumerable<FileReference>>
            (
                "FileReferencesByName",
                "FileReferences by file reference name",
                new QueryArguments
                (
                    QueryArgumentFactory.Create<StringGraphType>("FileReferenceName", "FileReferenceName")
                ), async context =>
                {
                    await Task.Delay(5000);
                    var fileReferenceName = context.GetArgument<string>("fileReferenceName");
                    return await dataStore.GetEntitiesAsync<FileReference>
                    (
                        p => p.FileReference1.StartsWith(fileReferenceName),
                        context.CancellationToken
                    );
                });

            #endregion

            #region File Reference By File Reference Id

            FieldAsync<FileReferenceGraphType, FileReference>
            (
                "FileReferenceById",
                "FileReference by file reference id",
                new QueryArguments
                (
                    QueryArgumentFactory.Create<IntGraphType>(ArgumentNames.FileReferenceId, Resources.The_file_reference_Id)
                ),
                context =>
                {
                    var fileReferenceId = context.GetArgument<int>(ArgumentNames.FileReferenceId);
                    return dataStore.GetEntityAsync<FileReference>(p => p.FileReferenceId == fileReferenceId, context.CancellationToken);
                });

            #endregion

            #region User Profile By User Id

            FieldAsync<ListGraphType<UserProfileGraphType>, IEnumerable<UserProfile>>
            (
                "UserProfilesByUserId",
                "Get all user profiles by a user's id",
                new QueryArguments
                (
                    QueryArgumentFactory.Create<IntGraphType>("userId", "Id of user")
                ),
                context =>
                {
                    var userId = context.GetArgument<int>("userId");

                    return dataStore.GetEntitiesAsync<UserProfile>
                    (
                        p => p.UserId == userId,
                        context.CancellationToken
                    );
                });

            #endregion

            #region User Profile By User Id And Profile Id

            FieldAsync<UserProfileGraphType, UserProfile>
            (
                "UserProfileByUserIdAndProfileId",
                "Gets a user's profile using the user id and profile id",
                new QueryArguments
                (
                    QueryArgumentFactory.Create<IntGraphType>("profileId", "Id of user's profile"),
                    QueryArgumentFactory.Create<IntGraphType>("userId", "Id of user")
                ),
                context =>
                {
                    var profileId = context.GetArgument<int>("profileId");
                    var userId = context.GetArgument<int>("userId");

                    return dataStore.GetEntityAsync<UserProfile>
                    (
                        p => p.ProfileId == profileId && p.UserId == userId,
                        context.CancellationToken
                    );
                });

            #endregion
        }
    }
}