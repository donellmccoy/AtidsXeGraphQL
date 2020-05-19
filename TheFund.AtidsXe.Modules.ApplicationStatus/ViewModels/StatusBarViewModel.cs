// ***********************************************************************
// Assembly         : TheFund.AtidsXe.Modules.ApplicationStatus
// Author           : Donell McCoy
// Created          : 11-01-2019
//
// Last Modified By : Donell McCoy
// Last Modified On : 03-18-2020
// ***********************************************************************
// <copyright file="StatusBarViewModel.cs" company="Attorneys' Title Fund Services, LLC">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************

using Prism.Events;
using ReactiveUI;
using System;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Services.Configuration;

namespace TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels
{
    /// <summary>
    /// Class StatusBarViewModel. This class cannot be inherited.
    /// Implements the <see cref="TheFund.AtidsXe.Modules.Common.ViewModels.ViewModelBase" />
    /// Implements the <see cref="TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels.IStatusBarViewModel" />
    /// </summary>
    /// <seealso cref="TheFund.AtidsXe.Modules.Common.ViewModels.ViewModelBase" />
    /// <seealso cref="TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels.IStatusBarViewModel" />
    [Export(typeof(IStatusBarViewModel))]
	[PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        #region Fields

        /// <summary>
        /// The default status
        /// </summary>
        private const string DEFAULT_STATUS = "Ready";

        /// <summary>
        /// The user information
        /// </summary>
        private string _userInfo;

        /// <summary>
        /// The status
        /// </summary>
        private string _status;

        /// <summary>
        /// The environment information
        /// </summary>
        private string _environmentInfo;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarViewModel" /> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="configurationService">The configuration service.</param>
        /// <param name="queue">The queue.</param>
        [ImportingConstructor]
        public StatusBarViewModel(IEventAggregator eventAggregator,
                                  IConfigurationService configurationService,
								  IStatusBarMessageQueue queue) : base(eventAggregator)
        {
			_status = DEFAULT_STATUS;
            _userInfo = $"User: {Environment.UserName}";
			_environmentInfo = $"Environment: {configurationService.Environment}";

            queue.RegisterHandler<IStatusBarMessage>(message => Status = message.StatusMessage);
        }

        #endregion

        #region Properties

        /// <inheritdoc />
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status
		{
			get => _status;
			set => this.RaiseAndSetIfChanged(ref _status, value);
		}

        /// <inheritdoc />
		/// <summary>
		/// Gets or sets the user information.
		/// </summary>
		/// <value>The user information.</value>
        public string UserInfo
		{
			get => _userInfo;
			set => this.RaiseAndSetIfChanged(ref _userInfo, value);
		}

        /// <inheritdoc />
		/// <summary>
		/// Gets or sets the environment information.
		/// </summary>
		/// <value>The environment information.</value>
        public string EnvironmentInfo
        {
			get => _environmentInfo;
			set => this.RaiseAndSetIfChanged(ref _environmentInfo, value);
		}

        #endregion
    }
}
