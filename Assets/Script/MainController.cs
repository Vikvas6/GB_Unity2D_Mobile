using Game;
using Profile;
using Ui;
using UnityEngine;
using Game.Features;
using Game.Inventory;
using Game.Item;
using Tools;
using System.Linq;
using Game.Reward;

public sealed class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private ShedController _shedController;
    private DailyRewardController _dailyRewardController;
    private CurrencyController _currencyController;
    private FightWindowController _fightController;
    
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _shedController?.Dispose();
                _dailyRewardController?.Dispose();
                _currencyController?.Dispose();
                _fightController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer, _shedController?.GetEquipedItems());
                _mainMenuController?.Dispose();
                _shedController?.Dispose();
                _dailyRewardController?.Dispose();
                _currencyController?.Dispose();
                _fightController?.Dispose();
                break;
            case GameState.Garage:
                _shedController = new ShedController(_placeForUi, _profilePlayer);
                _shedController.Enter();
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _dailyRewardController?.Dispose();
                _currencyController?.Dispose();
                _fightController?.Dispose();
                break;
            case GameState.Reward:
                _dailyRewardController = new DailyRewardController(_placeForUi, _profilePlayer);
                _currencyController = new CurrencyController(_placeForUi);
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _shedController?.Dispose();
                _fightController?.Dispose();
                break;
            case GameState.Fight:
                _fightController = new FightWindowController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _shedController?.Dispose();
                _dailyRewardController?.Dispose();
                _currencyController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _shedController?.Dispose();
                _dailyRewardController?.Dispose();
                _currencyController?.Dispose();
                _fightController?.Dispose();
                break;
        }
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }
}
