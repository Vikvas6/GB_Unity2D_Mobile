using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Game.InputLogic
{
    internal sealed class InputTapView : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed)
        {
            base.Init(leftMove, rightMove, speed);
            _buttonMove.onClick.AddListener(OnClick);
        }

        [SerializeField] 
        private Button _buttonMove;

        private void OnClick()
        {
            OnRightMove(Time.deltaTime * _speed);
        }
    }
}

