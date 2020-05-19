namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IPolicyWorksheetItemRepository
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<int, Entities.Models.PolicyWorksheetItem>> GetPolicyWorksheetItemsByIdAsync(System.Collections.Generic.IEnumerable<int> keys, System.Threading.CancellationToken token);
        System.Threading.Tasks.Task<System.Linq.ILookup<int, Entities.Models.PolicyWorksheetItem>> GetPolicyWorksheetItemsIdAsync(System.Collections.Generic.IEnumerable<int> keys);
    }
}