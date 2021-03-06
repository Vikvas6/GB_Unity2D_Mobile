using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainWindowObserver : MonoBehaviour
{
    [SerializeField] private TMP_Text _countMoneyText;
    [SerializeField] private TMP_Text _countHealthText;
    [SerializeField] private TMP_Text _countPowerText;
    [SerializeField] private TMP_Text _countPowerEnemyText;

    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private Button _minusCoinsButton;
    [SerializeField] private Button _addHealthButton;
    [SerializeField] private Button _minusHealthButton;
    [SerializeField] private Button _addPowerButton;
    [SerializeField] private Button _minusPowerButton;
    [SerializeField] private Button _fightButton;
    [SerializeField] private Button _exitButton;
 
    private int _allCountMoneyPlayer;
    private int _allCountHealthPlayer;
    private int _allCountPowerPlayer;
    private int _allCrimeLevelPlayer;
 
    private Money _money;
    private Health _heath;
    private Power _power;
 
    private Enemy _enemy;
    
    [SerializeField] private TMP_Text _crimeLevelText;
    [SerializeField] private Button _crimeLevelButton;
    [SerializeField] private Button _escapeButton;
    private CrimeLevel _crimeLevel;

    private void Start()
    {
        _enemy = new Enemy("Enemy Flappy");
    
        _money = new Money(nameof(Money));
        _money.Attach(_enemy);
    
        _heath = new Health(nameof(Health));
        _heath.Attach(_enemy);
    
        _power = new Power(nameof(Power));
        _power.Attach(_enemy);
    
        _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
        _minusCoinsButton.onClick.AddListener(() => ChangeMoney(false));
    
        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));
    
        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));
    
        _fightButton.onClick.AddListener(Fight);
        
        _crimeLevel = new CrimeLevel(nameof(CrimeLevel));
        _crimeLevel.Attach(_enemy);
        _crimeLevelButton.onClick.AddListener(ChangeCrimeLevel);
        _escapeButton.onClick.AddListener(Escape);
    }

    private void OnDestroy()
    {
        _addCoinsButton.onClick.RemoveAllListeners();
        _minusCoinsButton.onClick.RemoveAllListeners();
    
        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();
    
        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();
    
        _fightButton.onClick.RemoveAllListeners();
    
        _money.Detach(_enemy);
        _heath.Detach(_enemy);
        _power.Detach(_enemy);
        
        _escapeButton.onClick.RemoveAllListeners();
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
    }
 
    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }
 
    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }
 
    private void ChangeCrimeLevel()
    {
        _allCrimeLevelPlayer = Random.Range(0, 6);

        ChangeDataWindow(_allCrimeLevelPlayer, DataType.CrimeLevel);
    }

    private void Fight()
    {
        Debug.Log(_allCountPowerPlayer >= _enemy.Power
            ? "<color=#07FF00>Win!!!</color>"
            : "<color=#FF0000>Lose!!!</color>");
    }

    private void Escape()
    {
        Debug.Log("Trying to escape...");
        if (_crimeLevel.CrimeLevel < 3)
        {
            Debug.Log("<color=#0700FF>Escaped successfully</color>");
        }
        else
        {
            Debug.Log("<color=#FF0000>You cannot escape, FIGHT!!!</color>");
            Fight();
        }
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _countMoneyText.text = $"Player Money {countChangeData.ToString()}";
                _money.Money = countChangeData;
                break;
       
            case DataType.Health:
                _countHealthText.text = $"Player Health {countChangeData.ToString()}";
                _heath.Health = countChangeData;
                break;
       
            case DataType.Power:
                _countPowerText.text = $"Player Power {countChangeData.ToString()}";
                _power.Power = countChangeData;
                break;
       
            case DataType.CrimeLevel:
                _crimeLevelText.text = $"Player Crime Level {countChangeData.ToString()}";
                _crimeLevel.CrimeLevel = countChangeData;
                break;
        }
    
        _countPowerEnemyText.text = $"Enemy Power {_enemy.Power}";
    }
}
