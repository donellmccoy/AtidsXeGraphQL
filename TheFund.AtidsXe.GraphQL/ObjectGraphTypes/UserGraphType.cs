using GraphQL.Types;
using System.Collections.Generic;
using TheFund.AtidsXe.Data.Services;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.GraphQL.ObjectGraphTypes
{
    public sealed class UserGraphType : ObjectGraphType<User>
    {
        private readonly IEFDataStore _dataStore;

        public UserGraphType(IEFDataStore dataStore)
        {
            _dataStore = dataStore;

            Name = nameof(UserGraphType);
            Description = "UserGraphType";

            InitializePrimitiveTypes();
            InitializeComplexTypes();
        }

        private void InitializePrimitiveTypes()
        {
            Field(p => p.UserId);
            Field(p => p.FirstName);
            Field(p => p.MiddleName);
            Field(p => p.LastName);
            Field(p => p.UserName);
            Field(p => p.CreatedBy);
            Field(p => p.CreatedDate);
            Field(p => p.ModifiedBy);
            Field(p => p.ModifiedDate);
        }

        private void InitializeComplexTypes()
        {
            FieldAsync<ListGraphType<UserProfileGraphType>, IEnumerable<UserProfile>>
            (
                "UserProfiles",
                "User profiles",
                null,
                context =>
                {
                    return _dataStore.GetBatchedEntitiesAsync<UserProfile>
                    (
                        "UserProfiles",
                        context.Source.UserId,
                        p => p.UserId,
                        context.CancellationToken
                    );
                });
        }
    }
}