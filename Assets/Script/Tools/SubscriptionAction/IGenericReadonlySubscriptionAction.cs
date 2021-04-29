using System;

namespace Tools
{
    public interface IGenericReadonlySubscriptionAction<T>
    {
        void Invoke(T obj);
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnSubscriptionOnChange(Action<T> unsubscriptionAction);
    }
}