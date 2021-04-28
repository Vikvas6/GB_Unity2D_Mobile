using System.Linq;
using System.Collections.Generic;
using Game.Inventory;
using Game.Item;
using JetBrains.Annotations;
using Profile;
using Tools;
using Ui;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Game.Features
{
    public class ShedController : BaseController, IShedController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/shedMenu"};
        private readonly IUpgradable _upgradable;
        private readonly ProfilePlayer _profilePlayer;

        private readonly IRepository<int, IUpgradeHandler> _upgradeHandlersRepository;
        private readonly IInventoryController _inventoryController;
        
        private readonly ShedView _view;

        #region Life cycle
        
        public ShedController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
            _upgradable = profilePlayer.CurrentCar;
            
            var upgradeItemsConfigCollection = ContentDataSourceLoader.LoadUpgradeItemConfigs(new ResourcePath { PathResource = "DataSource/Upgrade/UpgradeItemConfigDataSource" });
            var upgradeItemsRepository = new UpgradeHandlersRepository(upgradeItemsConfigCollection);
            _upgradeHandlersRepository = upgradeItemsRepository;

            var itemsRepository = new ItemsRepository(upgradeItemsConfigCollection.Select(value => value.itemConfig).ToList());
            var inventoryModel = new InventoryModel();
            var inventoryViewPath = new ResourcePath { PathResource = $"Prefabs/{nameof(InventoryView)}" };

            var inventoryView = ResourceLoader.LoadAndInstantiateObject<InventoryView>(inventoryViewPath, placeForUi, false);
            AddGameObjects(inventoryView.gameObject);

            var inventoryController = new InventoryController(itemsRepository, inventoryModel, inventoryView);
            AddController(inventoryController);
            _inventoryController =  inventoryController;
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

        public IReadOnlyList<IItem> GetEquipedItems()
        {
            return _inventoryController.GetEquippedItems();
        }

        public void Enter()
        {
            _inventoryController.ShowInventory(Exit);
        }
        
        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _upgradable, _inventoryController.GetEquippedItems(), _upgradeHandlersRepository.Collection);
        }

        private ShedView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<ShedView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game");
        }

        #endregion
    }
}