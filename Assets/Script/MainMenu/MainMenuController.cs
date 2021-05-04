using Profile;
using Tools;
using UnityEngine;
using Game.Features;
using Game.Item;
using Game.Inventory;
using System.Linq;
using System.Collections.Generic;


namespace Ui
{
    public class MainMenuController : BaseController
    {
        #region Fields
        
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        
        private readonly ShedController _shedController;

        #endregion

        #region Life cycle
        
        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, EnterShed, EnterReward);
            
            AddController(new CursorTrailController());
            
            /*_shedController = ConfigureShedController(placeForUi, profilePlayer);
            _shedController.Enter();*/
        }

        #endregion

        #region Methods

        public IReadOnlyList<IItem> GetEquipedItems()
        {
            return _shedController.GetEquipedItems();
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        /*private ShedController ConfigureShedController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            var upgradeItemsConfigCollection = ContentDataSourceLoader.LoadUpgradeItemConfigs(new ResourcePath { PathResource = "DataSource/Upgrade/UpgradeItemConfigDataSource" });
            var upgradeItemsRepository = new UpgradeHandlersRepository(upgradeItemsConfigCollection);

            var itemsRepository = new ItemsRepository(upgradeItemsConfigCollection.Select(value => value.itemConfig).ToList());
            var inventoryModel = new InventoryModel();
            var inventoryViewPath = new ResourcePath { PathResource = $"Prefabs/{nameof(InventoryView)}" };

            var inventoryView = ResourceLoader.LoadAndInstantiateObject<InventoryView>(inventoryViewPath, placeForUi, false);
            AddGameObjects(inventoryView.gameObject);

            var inventoryController = new InventoryController(itemsRepository, inventoryModel, inventoryView);
            AddController(inventoryController);

            var shedController = new ShedController(upgradeItemsRepository, inventoryController, profilePlayer.CurrentCar);
            AddController(shedController);

            return shedController;
        }*/

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game");
        }

        private void EnterShed()
        {
            _profilePlayer.CurrentState.Value = GameState.Garage;
            _profilePlayer.AnalyticTools.SendMessage("enter_shed");
        }

        private void EnterReward()
        {
            _profilePlayer.CurrentState.Value = GameState.Reward;
            _profilePlayer.AnalyticTools.SendMessage("enter_reward");
        }

        #endregion
    }
}

