using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace Ui
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonShed;
        [SerializeField] private Button _buttonReward;

        public void Init(UnityAction startGame, UnityAction enterShed, UnityAction openRewards)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonShed.onClick.AddListener(enterShed);
            _buttonReward.onClick.AddListener(openRewards);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
        }
    }
}

