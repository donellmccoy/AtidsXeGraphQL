namespace TheFund.AtidsXe.Modules.Search.Enumerations
{
	public enum SearchTrigger
	{
		UserKeysSearchTerm,
		UserSelectsSearchTerm,
		UserClearsSearchTerm,
		UserCancelsSearch,
		UserOpensFileReference,
		UserClosesFileReference,
		UserAddsFavorite,
		UserRemovesFavorite,

		ServerSendsSearchResults,
        ServerCancelled,
        ServerCancellationError,

		InternalError
	}
}