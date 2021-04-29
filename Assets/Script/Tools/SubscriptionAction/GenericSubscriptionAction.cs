using System;

namespace Tools
{
    public class GenericSubscriptionAction<T> : IGenericReadonlySubscriptionAction<T>
    {
        private Action<T> _action;

        public void Invoke(T obj)
        {
            _action?.Invoke(obj);
        }
        
        public void SubscribeOnChange(Action<T> subscriptionAction)
        {
            _action += subscriptionAction;
        }

        public void UnSubscriptionOnChange(Action<T> unsubscriptionAction)
        {
            _action -= unsubscriptionAction;
        }
    }
}