using Game.Item;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace Game.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _itemText;
        [SerializeField] private Image _unactiveBackground;
        [SerializeField] private Image _activeBackground;

        private bool _isSelectedState = false;

        public void SetupItem(IItem item, Action<IItem> Selected, Action<IItem> Unselected)
        {
            _itemText.text = item.Info.Title;

            _button.onClick.AddListener(() =>
            {
                _isSelectedState = !_isSelectedState;

                if (_isSelectedState)
                    Selected.Invoke(item);
                else
                    Unselected.Invoke(item);

                SelectBackground();
            });

            SelectBackground();
        }

        private void SelectBackground()
        {
            _activeBackground.gameObject.SetActive(_isSelectedState);
            _unactiveBackground.gameObject.SetActive(!_isSelectedState);
        }
    }
}