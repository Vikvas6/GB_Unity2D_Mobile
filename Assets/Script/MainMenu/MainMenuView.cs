using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Game.Tweening;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using System;

namespace Ui
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonShed;
        [SerializeField] private Button _buttonReward;
        [SerializeField] private Button _buttonFight;
        [SerializeField] private Button _buttonOpenPopup;
        [SerializeField] private Button _buttonExit;
        
        [SerializeField] private Text _buttonStartText;
        [SerializeField] private Text _buttonShedText;
        [SerializeField] private Text _buttonRewardText;
        [SerializeField] private Text _buttonFightText;
        [SerializeField] private Text _buttonOpenPopupText;
        [SerializeField] private Text _buttonExitText;
        
        [SerializeField] private PopupView _popupView;
  
        [SerializeField] private Button _russianButton;
        [SerializeField] private Button _englishButton;
        
        [SerializeField] private Button _buttonNotification;
        [SerializeField] private Text _buttonNotificationText;

        private const string AndroidNotifierId = "android_notifier_id";
        
        public void Init(UnityAction startGame, UnityAction enterShed, UnityAction openRewards, UnityAction fight)
        {
            ChangedLocaleEvent(null);
            LocalizationSettings.SelectedLocaleChanged += ChangedLocaleEvent;
            
            _buttonStart.onClick.AddListener(startGame);
            _buttonShed.onClick.AddListener(enterShed);
            _buttonReward.onClick.AddListener(openRewards);
            _buttonFight.onClick.AddListener(fight);
            _buttonOpenPopup.onClick.AddListener(_popupView.ShowPopup);
            _buttonExit.onClick.AddListener(ExitGame);
            
            _russianButton.onClick.AddListener(() => ChangeLanguage(2));
            _englishButton.onClick.AddListener(() => ChangeLanguage(0));
            
            _buttonNotification.onClick.AddListener(CreateNotification);
        }

        private void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonShed.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
            _buttonFight.onClick.RemoveAllListeners();
            _buttonOpenPopup.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        private void ChangedLocaleEvent(Locale locale)
        {
            StartCoroutine(OnChangedLocale(locale));
        }

        private IEnumerator OnChangedLocale(Locale locale)
        {
            var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("Game");
            yield return loadingOperation;
            if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
            {
                var table = loadingOperation.Result;
                _buttonStartText.text = table.GetEntry("start")?.GetLocalizedString();
                _buttonShedText.text = table.GetEntry("shed")?.GetLocalizedString();
                _buttonRewardText.text = table.GetEntry("daily_reward")?.GetLocalizedString();
                _buttonFightText.text = table.GetEntry("fight")?.GetLocalizedString();
                _buttonOpenPopupText.text = table.GetEntry("show_popup")?.GetLocalizedString();
                _buttonExitText.text = table.GetEntry("exit")?.GetLocalizedString();
                _buttonNotificationText.text = table.GetEntry("notification")?.GetLocalizedString();
            }
            else
            {
                Debug.Log("Could not load String Table\n" + loadingOperation.OperationException);
            }
        }

        private void ChangeLanguage(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }

        private void CreateNotification()
        {
#if UNITY_ANDROID
            var androidSettingsChanel = new AndroidNotificationChannel
            {
                Id = AndroidNotifierId,
                Name = "Game Notifier",
                Importance =  Importance.High,
                CanBypassDnd = true,
                CanShowBadge = true,
                Description = "Enter the game and get free crystals",
                EnableLights = true,
                EnableVibration = true,
                LockScreenVisibility = LockScreenVisibility.Public
            };
      
            AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);
      
            var androidSettingsNotification = new AndroidNotification
            {
                Color = Color.white,
                RepeatInterval = TimeSpan.FromSeconds(5)
            };

            AndroidNotificationCenter.SendNotification(androidSettingsNotification, AndroidNotifierId);
#elif UNITY_IOS
       var iosSettingsNotification = new iOSNotification
       {
           Identifier = "android_notifier_id",
           Title = "Game Notifier",
           Subtitle = "Subtitle notifier",
  Body = "Enter the game and get free crystals",
           Badge = 1,
           Data = "01/02/2021",
           ForegroundPresentationOption = PresentationOption.Alert,
           ShowInForeground = false
       };
      
       iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);
#endif
        }
    }
}

