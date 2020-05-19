namespace TheFund.AtidsXe.Modules.Common.Models 
{
	public sealed class StatusBarMessage : IStatusBarMessage
	{
		private const string DEFAULT_STATUS = "Ready";

		public StatusBarMessage(string message)
		{
			StatusMessage = string.IsNullOrWhiteSpace(message) ? DEFAULT_STATUS : message;
		}

		public string StatusMessage { get; }
	}
}