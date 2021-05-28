using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Game.Tweening;

namespace Ui
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonShed;
        [SerializeField] private Button _buttonReward;
        [SerializeField] private Button _buttonFight;
        [SerializeField] private Button _buttonOpenPopup;
        [SerializeField] private Button _buttonExit;
        
        [SerializeField] private PopupView _popupView;

        public void Init(UnityAction startGame, UnityAction enterShed, UnityAction openRewards, UnityAction fight)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonShed.onClick.AddListener(enterShed);
            _buttonReward.onClick.AddListener(openRewards);
            _buttonFight.onClick.AddListener(fight);
            _buttonOpenPopup.onClick.AddListener(_popupView.ShowPopup);
            _buttonExit.onClick.AddListener(ExitGame);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
            _buttonFight.onClick.RemoveAllListeners();
            _buttonOpenPopup.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

