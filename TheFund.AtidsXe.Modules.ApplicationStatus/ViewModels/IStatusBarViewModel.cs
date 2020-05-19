using System;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;

namespace TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels
{
    public interface IStatusBarViewModel
    {
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		string Status { get; set; }

		/// <summary>
		/// Gets or sets the user information.
		/// </summary>
		/// <value>The user information.</value>
		string UserInfo { get; set; }

		/// <summary>
		/// Gets or sets the environment information.
		/// </summary>
		/// <value>The environment information.</value>
		string EnvironmentInfo { get; set; }
	}
}