using System;
using Profile;
using Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    public class StartStateButton : MonoBehaviour, IMainMenuStateButton
    {
        public GameState GameStateChanger => _gameState;
        
        [SerializeField] private GameState _gameState;
        [SerializeField] private Button _button;

        private IGenericReadonlySubscriptionAction<GameState> _changeGameStateAction;

        private void Awake()
        {
            _button.onClick.AddListener(OnStartButtonClick);
            _changeGameStateAction = new GenericSubscriptionAction<GameState>();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void AddListener(Action<GameState> action)
        {
            _changeGameStateAction.SubscribeOnChange(action);
        }

        public void RemoveListener(Action<GameState> action)
        {
            _changeGameStateAction.UnSubscriptionOnChange(action);
        }

        private void OnStartButtonClick()
        {
            _changeGameStateAction.Invoke(_gameState);
        }
    }
}