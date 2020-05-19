namespace TheFund.AtidsXe.Modules.Services.GraphQL
{
    public interface IQueryCreationService
    {
        string CreateFileReferencesNameQuery(string fileReferenceName);
        string CreateFileReferenceQuery(int fileReferenceId);
        string CreateUserProfileQuery(int userId, int profileId);
        string CreateUserProfilesQuery(int userId);
    }
}