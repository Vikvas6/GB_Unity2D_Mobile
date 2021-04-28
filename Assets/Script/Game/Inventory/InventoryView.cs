using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Item;

namespace Game.Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        #region Fields
        
        [SerializeField] private RectTransform _itemsParent;
        [SerializeField] private InventoryItemView _inventoryItemView;

        private List<IItem> _itemInfoCollection;
        
        #endregion

        #region IInventoryView
        
        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        public void Show()
        {
            foreach (IItem item in _itemInfoCollection)
            {
                InventoryItemView itemView = Instantiate(_inventoryItemView, _itemsParent);
                itemView.SetupItem(item, OnSelected, OnDeselected);
            }
        }
        
        public void Hide()
        {
        }
        
        public void Display(List<IItem> itemInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;
        }

        protected virtual void OnSelected(IItem e)
        {
            Selected?.Invoke(this, e);
        }

        protected virtual void OnDeselected(IItem e)
        {
            Deselected?.Invoke(this, e);
        }

        #endregion
    }
}
