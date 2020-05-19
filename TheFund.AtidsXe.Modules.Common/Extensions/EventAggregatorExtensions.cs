using Prism.Events;
using System;

namespace TheFund.AtidsXe.Modules.Common.Extensions
{
    public static class EventAggregatorExtensions
    {
        public static void Publish<TEventType, TPayload>(this IEventAggregator eventAggregator, TPayload payload) where TEventType : PubSubEvent<TPayload>, new()
        {
            eventAggregator.GetEvent<TEventType>().Publish(payload);
        }

        public static void Publish<TEventType>(this IEventAggregator eventAggregator) where TEventType : PubSubEvent, new()
        {
            eventAggregator.GetEvent<TEventType>().Publish();
        }

        public static SubscriptionToken Subscribe<TEventType, TPayload>(this IEventAggregator eventAggregator, Action<TPayload> action, ThreadOption threadOption = ThreadOption.PublisherThread) where TEventType : PubSubEvent<TPayload>, new()
        {
            return eventAggregator.GetEvent<TEventType>().Subscribe(action, threadOption, false);
        }

        public static SubscriptionToken Subscribe<TEventType>(this IEventAggregator eventAggregator, Action action, ThreadOption threadOption = ThreadOption.PublisherThread) where TEventType : PubSubEvent, new()
        {
            return eventAggregator.GetEvent<TEventType>().Subscribe(action, threadOption, false);
        }
    }
}
