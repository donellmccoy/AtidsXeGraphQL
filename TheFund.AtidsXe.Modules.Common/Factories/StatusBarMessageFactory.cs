using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Factories
{
	public static class StatusBarMessageFactory
    {
        public static IStatusBarMessage Create(string message = null)
        {
            return new StatusBarMessage(message);
        }
    }
}