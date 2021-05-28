using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Tweening
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private Button _buttonClosePopup;
        [SerializeField] private Button _buttonChangeText;
        [SerializeField] private Text _changeText;

        [SerializeField] private float _duration = 0.3f;

        private void Start()
        {
            _buttonClosePopup.onClick.AddListener(HidePopup);
            _buttonChangeText.onClick.AddListener(ChangeText);
        }

        private void OnDestroy()
        {
            _buttonClosePopup.onClick.RemoveAllListeners();
            _buttonChangeText.onClick.RemoveAllListeners();
        }

        public void ShowPopup()
        {
            gameObject.SetActive(true);

            AnimationShow();
        }

        public void HidePopup()
        {
            AnimationHide();
        }

        private void AnimationShow()
        {
            var sequence = DOTween.Sequence();

            sequence.Insert(0.0f, transform.DOScale(Vector3.one, _duration));
            sequence.OnComplete(() => { sequence = null; });
        }

        private void AnimationHide()
        {
            var sequence = DOTween.Sequence();

            sequence.Insert(0.0f, transform.DOScale(Vector3.zero, _duration));
            sequence.OnComplete(() =>
            {
                sequence = null;
                gameObject.SetActive(false);
            });
        }
        private void ChangeText()
        {
            _changeText.DOText("This is VERY nice PopUp!", 1.0f).SetEase(Ease.Linear);
        }

    }

}