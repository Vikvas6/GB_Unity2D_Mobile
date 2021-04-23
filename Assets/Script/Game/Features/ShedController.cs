using System;
using System.Collections.Generic;
using Game.Inventory;
using Game.Item;
using JetBrains.Annotations;


namespace Game.Features
{
    public class ShedController : BaseController, IShedController
    {
        private readonly IUpgradable _upgradable;
        
        private readonly IRepository<int, IUpgradeHandler> _upgradeHandlersRepository;
        private readonly IInventoryController _inventoryController;

        #region Life cycle
        
        public ShedController(
            [NotNull] IRepository<int, IUpgradeHandler> upgradeHandlersRepository,
            [NotNull] IInventoryController inventoryController,
            [NotNull] IUpgradable upgradable)
        {
            _upgradeHandlersRepository 
                = upgradeHandlersRepository ?? throw new ArgumentNullException(nameof(upgradeHandlersRepository));
            
            _inventoryController 
                =  inventoryController ?? throw new ArgumentNullException(nameof(inventoryController));;
            
            _upgradable = upgradable ?? throw new ArgumentNullException(nameof(upgradable));
        }

        #endregion
        
        #region Methods
        
        private void UpgradeCarWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<IItem> equippedItems, 
            IReadOnlyDictionary<int, IUpgradeHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                {
                    handler.Upgrade(upgradable);
                }
            }
        }

        #endregion
        
        #region IShedController

        public void Enter()
        {
            _inventoryController.ShowInventory(Exit);
        }
        
        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _upgradable, _inventoryController.GetEquippedItems(), _upgradeHandlersRepository.Collection);
        }

        #endregion
    }
}