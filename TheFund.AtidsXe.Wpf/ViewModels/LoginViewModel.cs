using Prism.Events;
using ReactiveUI;
using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Wpf.ViewModels
{
    [Export(typeof(ILoginViewModel))]
    public class LoginViewModel : ReactiveObject, ILoginViewModel
    {
        [ImportingConstructor]
        public LoginViewModel(IEventAggregator eventAggregator)
        {

        }
    }
}
