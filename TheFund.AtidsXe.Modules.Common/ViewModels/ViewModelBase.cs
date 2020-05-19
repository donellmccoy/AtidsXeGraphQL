using Prism.Events;
using ReactiveUI;
using System;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;
		private string _statusBarMessage;

        #endregion

        #region Constructors

        protected ViewModelBase(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        protected ViewModelBase()
        {

        }

        static ViewModelBase()
        {
            
        }


        #endregion

        #region Properties

		protected string StatusBarMessage
		{
			get => _statusBarMessage;
			set => this.RaiseAndSetIfChanged(ref _statusBarMessage, value);
		}

        #endregion

        #region Methods

        protected void HideStatusBarMessage()
		{
			//ShowStatusBarMessage();
		}

        protected virtual void Publish<TEventType>() where TEventType : PubSubEvent, new()
        {
            _eventAggregator.Publish<TEventType>();
        }

        protected virtual void Publish<TEventType, TPayload>(TPayload payload) where TEventType : PubSubEvent<TPayload>, new()
        {
            _eventAggregator.Publish<TEventType, TPayload>(payload);
        }

        protected virtual void Publish<TEventType, TPayload>(Func<TPayload> func) where TEventType : PubSubEvent<TPayload>, new()
        {
            _eventAggregator.Publish<TEventType, TPayload>(func());
        }

        protected virtual void Subscribe<TEventType, TPayload>(Action<TPayload> action, ThreadOption threadOption = ThreadOption.PublisherThread) where TEventType : PubSubEvent<TPayload>, new()
        {
            _eventAggregator.Subscribe<TEventType, TPayload>(action, threadOption);
        }

        protected virtual void Subscribe<TEventType>(Action action, ThreadOption threadOption = ThreadOption.PublisherThread) where TEventType : PubSubEvent, new()
        {
            _eventAggregator.Subscribe<TEventType>(action, threadOption);
        }

        #endregion
	}
}
