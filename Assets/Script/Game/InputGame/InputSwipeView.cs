using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.InputLogic
{
    internal sealed class InputSwipeView : BaseInputView, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        private float _threshold = 40;
        private Vector2 _startPosition;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float diff = eventData.position.x - _startPosition.x;
            if (Mathf.Abs(diff) >= _threshold)
            {
                if(diff > 0)
                    OnRightMove(_speed * Time.deltaTime);
                else
                    OnLeftMove(-_speed * Time.deltaTime);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}

