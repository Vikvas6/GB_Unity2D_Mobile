using System.Collections.Generic;
using Game.Item;


namespace Game.Inventory
{
    public class InventoryModel : IInventoryModel
    {
        #region Fields
        
        private readonly IReadOnlyList<IItem> _stubCollection = new List<IItem>();
        private readonly List<IItem> _equippedItems = new List<IItem>();
        
        #endregion

        #region IInventoryModel
        
        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _equippedItems ?? _stubCollection;
        }

        public void EquipItem(IItem item)
        {
            if (_equippedItems.Contains(item)) return;
            _equippedItems.Add(item);
        }

        public void UnequipItem(IItem item)
        {
            if (!_equippedItems.Contains(item)) return;
            _equippedItems.Remove(item);
        }
        
        #endregion
    }
}

