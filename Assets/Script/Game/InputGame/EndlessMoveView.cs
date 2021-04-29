using JoostenProductions;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal sealed class EndlessMoveView : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, SubscriptionProperty<float> speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(MoveToRight);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(MoveToRight);
        }

        private void MoveToRight()
        {
            OnRightMove(_speed.Value * Time.deltaTime);
        }
    }
}

