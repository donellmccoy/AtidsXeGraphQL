using Prism.Events;
using ReactiveUI;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.Events;

namespace TheFund.AtidsXe.Wpf.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : ReactiveObject, IShellViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private bool _isBusy;
        private string _busyMessage;

        [ImportingConstructor]
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            InitializeSubscriptions();
        }

        public string BusyMessage
        {
            get => _busyMessage;
            set
            {
                _busyMessage = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                this.RaisePropertyChanged();
            }
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator.GetEvent<ShellBusyIndicatorOffEvent>().Subscribe(() =>
            {
                IsBusy = false;
                BusyMessage = null;
            }, ThreadOption.UIThread);

            _eventAggregator.GetEvent<ShellBusyIndicatorOnEvent>().Subscribe(arg =>
            {
                IsBusy = true;
                BusyMessage = arg.Message;
            }, ThreadOption.UIThread);
        }
    }
}
