using GraphQL.Types;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class UserProfileFileReferenceGraphType : ObjectGraphType<UserProfileFileReference>
    {
        private readonly IEFDataStore _dataStore;

        public UserProfileFileReferenceGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Name = nameof(UserProfileFileReferenceGraphType);
            Description = "UserProfileFileReferenceGraphType";

            InitializePrimitiveTypes();
            InitializeComplexTypes();
        }

        private void InitializePrimitiveTypes()
        {
            Field(p => p.ProfileId);
            Field(p => p.UserId);
            Field(p => p.FileReferenceId);
            Field(p => p.CreatedBy);
            Field(p => p.CreatedDate);
            Field(p => p.ModifiedBy);
            Field(p => p.ModifiedDate);
        }

        private void InitializeComplexTypes()
        {
            FieldAsync<UserProfileGraphType, UserProfile>(
                "UserProfile",
                "UserProfile",
                null,
                context =>
                {
                    return _dataStore.GetEntityAsync<UserProfile>(p => p.ProfileId == context.Source.ProfileId, context.CancellationToken);
                });

            FieldAsync<UserGraphType, User>(
                "User",
                "User",
                null,
                context =>
                {
                    return _dataStore.GetEntityAsync<User>(p => p.UserId == context.Source.UserId, context.CancellationToken);
                });

            FieldAsync<FileReferenceGraphType, FileReference>(
                "FileReference",
                "FileReference",
                null,
                context =>
                {
                    return _dataStore.GetEntityAsync<FileReference>(p => p.FileReferenceId == context.Source.FileReferenceId, context.CancellationToken);
                });
        }
    }
}