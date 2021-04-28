using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace Ui
{
    public sealed class ShedView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
        }
    }
}