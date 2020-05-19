using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.Search.ViewModels 
{
	[Export(typeof(ISearchProgressViewModel))]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public sealed class SearchProgressViewModel : ISearchProgressViewModel
	{

	}
}