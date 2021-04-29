using System;
using Game.Inventory;
using Profile;
using UnityEngine;
using Tools;
using Game.UI;

namespace Game.Garage
{
    public class GarageView : MonoBehaviour, IInitialize<Action<GameState>>
    {
        public InventoryView InventoryView => _inventoryView;

        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private StartStateButton _startStateButton;

        public void Init(Action<GameState> initObject)
        {
            _startStateButton.AddListener(initObject);
        }
    }
}
