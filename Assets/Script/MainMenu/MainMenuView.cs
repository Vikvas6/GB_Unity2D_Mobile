using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace Ui
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonShed;

        public void Init(UnityAction startGame, UnityAction enterShed)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonShed.onClick.AddListener(enterShed);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
        }
    }
}

