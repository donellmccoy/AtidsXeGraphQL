// ***********************************************************************
// Assembly         : TheFund.AtidsXe.Modules.ApplicationStatus
// Author           : Donell McCoy
// Created          : 11-01-2019
//
// Last Modified By : Donell McCoy
// Last Modified On : 03-18-2020
// ***********************************************************************
// <copyright file="StatusBarView.xaml.cs" company="Attorneys' Title Fund Services, LLC">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using ReactiveUI;
using System.ComponentModel.Composition;
using System.Reactive.Disposables;
using TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels;

namespace TheFund.AtidsXe.Modules.ApplicationStatus.Views
{
	/// <summary>
	/// Class StatusBarView.
	/// Implements the <see cref="T:TheFund.AtidsXe.Modules.ApplicationStatus.Views.StatusBarViewBase" />
	/// Implements the <see cref="T:TheFund.AtidsXe.Modules.ApplicationStatus.Views.IStatusBarView" />
	/// Implements the <see cref="T:System.Windows.Markup.IComponentConnector" />
	/// </summary>
	/// <seealso cref="T:TheFund.AtidsXe.Modules.ApplicationStatus.Views.StatusBarViewBase" />
	/// <seealso cref="T:TheFund.AtidsXe.Modules.ApplicationStatus.Views.IStatusBarView" />
	/// <seealso cref="T:System.Windows.Markup.IComponentConnector" />
	[Export(typeof(IStatusBarView))]
    public partial class StatusBarView : IStatusBarView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarView"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        [ImportingConstructor]
        public StatusBarView(IStatusBarViewModel model)
        {
            InitializeComponent();

			ViewModel = model as StatusBarViewModel;

            this.WhenActivated(disposable =>
			{
				this.OneWayBind(ViewModel, viewModel => viewModel.Status, view => view.StatusLabel.Content)
					.DisposeWith(disposable);
				this.OneWayBind(ViewModel, viewModel => viewModel.UserInfo, view => view.UserInfoLabel.Content)
					.DisposeWith(disposable);
				this.OneWayBind(ViewModel, viewModel => viewModel.EnvironmentInfo, view => view.EnvironmentInfoLabel.Content)
					.DisposeWith(disposable);
			});
        }
    }
}
