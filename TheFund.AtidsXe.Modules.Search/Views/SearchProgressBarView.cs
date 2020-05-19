using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.Search.Views
{
	[Export(typeof(ISearchProgressBarView))]
	public partial class SearchProgressBarView : SearchProgressViewBase, ISearchProgressBarView
	{
		public SearchProgressBarView()
		{
			InitializeComponent();
		}
	}
}
