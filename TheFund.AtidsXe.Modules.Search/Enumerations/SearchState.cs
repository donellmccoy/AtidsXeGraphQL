namespace TheFund.AtidsXe.Modules.Search.Enumerations
{
    internal enum SearchState
    {
        Idle,
        Searching,
        Searched,
        Cancelling,
        Cancelled,

        OpeningFileReference,
        FileReferenceOpened,
        ClosingFileReference,
        FileReferenceClosed,
        AddingFavorite,
        FavoriteAdded,
        RemovingFavorite,
        FavoriteRemoved,

        Error
    }
}