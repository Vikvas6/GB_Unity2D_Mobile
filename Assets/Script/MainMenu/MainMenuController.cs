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
            _view.Init(StartGame, EnterShed, EnterReward, StartFight);
            
            AddController(new CursorTrailController());
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

        private void StartFight()
        {
            _profilePlayer.CurrentState.Value = GameState.Fight;
            _profilePlayer.AnalyticTools.SendMessage("start_fight");
        }

        #endregion
    }
}

