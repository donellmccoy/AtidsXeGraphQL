namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IWorksheetItemRepository
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<int, Entities.Models.WorksheetItem>> GetWorksheetItemsByIdAsync(System.Collections.Generic.IEnumerable<int> keys, System.Threading.CancellationToken token);
        System.Threading.Tasks.Task<System.Linq.ILookup<int, Entities.Models.WorksheetItem>> GetWorksheetItemsIdAsync(System.Collections.Generic.IEnumerable<int> keys);
    }
}