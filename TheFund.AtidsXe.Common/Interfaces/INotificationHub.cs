using System.Threading.Tasks;

namespace TheFund.AtidsXe.Common.Interfaces
{
    public interface INotificationHub
    {
        Task OnRegistrationCompleted(string connectionId);

        Task OnRegistrationCompleted(int searchId, string connectionId);

        Task OnSearchResultsReady();
    }
}