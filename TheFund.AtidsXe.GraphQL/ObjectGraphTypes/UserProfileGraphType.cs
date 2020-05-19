using GraphQL.Types;
using System.Collections.Generic;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class UserProfileGraphType : ObjectGraphType<UserProfile>
    {
        private readonly IEFDataStore _dataStore;

        public UserProfileGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Name = nameof(UserProfileGraphType);
            Description = "UserProfileGraphType";

            InitializePrimitiveTypes();
            InitializeComplexTypes();
        }

        private void InitializePrimitiveTypes()
        {
            Field(p => p.ProfileId);
            Field(p => p.UserId);
            Field(p => p.Name);
            Field(p => p.Description, true);
            Field(p => p.CreatedBy);
            Field(p => p.CreatedDate);
            Field(p => p.ModifiedBy);
            Field(p => p.ModifiedDate);
        }

        private void InitializeComplexTypes()
        {
            FieldAsync<UserGraphType, User>(
                "User",
                "User",
                null,
                context =>
                {
                    return _dataStore.GetEntityAsync<User>(p => p.UserId == context.Source.UserId, context.CancellationToken);
                });

            FieldAsync<ListGraphType<UserProfileFileReferenceGraphType>, IEnumerable<UserProfileFileReference>>
            (
                "UserProfileFileReferences",
                "",
                null,
                context =>
                {
                    return _dataStore.GetBatchedEntitiesAsync<UserProfileFileReference>
                    (
                        "UserProfileFileReferences",
                        context.Source.ProfileId,
                        p => p.ProfileId,
                        context.CancellationToken
                    );
                });

        }
    }
}