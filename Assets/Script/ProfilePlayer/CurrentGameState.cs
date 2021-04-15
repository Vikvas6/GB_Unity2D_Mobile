using System;

namespace Profile
{
    internal class CurrentGameState
    {
        public GameState State
        {
            get => _state;
            set
            {
                _state = value;
                _onChangedState?.Invoke(_state);
            }
        }

        public void SubscribeOnChange(Action<GameState> subscriptionAction)
        {
            _onChangedState += subscriptionAction;
        }

        public void UnSubscriptionOnChange(Action<GameState> unsubscriptionAction)
        {
            _onChangedState -= unsubscriptionAction;
        }

        private GameState _state;
        private Action<GameState> _onChangedState;
    }
}

