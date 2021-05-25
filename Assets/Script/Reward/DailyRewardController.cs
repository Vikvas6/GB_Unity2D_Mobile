using System;
using System.Collections;
using System.Collections.Generic;
using Profile;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Reward
{
    public class DailyRewardController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Reward Window"};
        private DailyRewardView _dailyRewardView;
        private List<ContainerSlotRewardView> _slots;
        private ProfilePlayer _profilePlayer;

        private bool _isGetReward;

        public DailyRewardController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _dailyRewardView = LoadView(placeForUi);
            RefreshView();
            AddGameObjects(_dailyRewardView.gameObject);
            _profilePlayer = profilePlayer;
        }

        private DailyRewardView LoadView(Transform placeForUi)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<DailyRewardView>();
        }
        
        public void RefreshView()
        {
            InitSlots();

            _dailyRewardView.StartCoroutine(RewardsStateUpdater());

            RefreshUi();
            SubscribeButtons();
        }

        private void InitSlots()
        {
            _slots = new List<ContainerSlotRewardView>();

            for (var i = 0; i < _dailyRewardView.Rewards.Count; i++)
            {
                var instanceSlot = GameObject.Instantiate(_dailyRewardView.ContainerSlotRewardView,
                    _dailyRewardView.MountRootSlotsReward, false);

                _slots.Add(instanceSlot);
            }
        }

        private IEnumerator RewardsStateUpdater()
        {
            while (true)
            {
                RefreshRewardsState();
                yield return new WaitForSeconds(1);
            }
        }

        private void RefreshRewardsState()
        {
            _isGetReward = true;

            if (_dailyRewardView.TimeGetReward.HasValue)
            {
                var timeSpan = DateTime.UtcNow - _dailyRewardView.TimeGetReward.Value;

                if (timeSpan.Seconds > _dailyRewardView.TimeDeadline)
                {
                    _dailyRewardView.TimeGetReward = null;
                    _dailyRewardView.CurrentSlotInActive = 0;
                }
                else if (timeSpan.Seconds < _dailyRewardView.TimeCooldown)
                {
                    _isGetReward = false;
                }
            }

            RefreshUi();
        }

        private void RefreshUi()
        {
            _dailyRewardView.GetRewardButton.interactable = _isGetReward;

            if (_isGetReward)
            {
                _dailyRewardView.TimerNewReward.text = "The reward is received today";
                _dailyRewardView.TimerSlider.value = 1.0f;
            }
            else
            {
                if (_dailyRewardView.TimeGetReward != null)
                {
                    var nextClaimTime = _dailyRewardView.TimeGetReward.Value.AddSeconds(_dailyRewardView.TimeCooldown);
                    var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;
                    var timeGetReward =
                        $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                    _dailyRewardView.TimerNewReward.text = $"Time to get the next reward: {timeGetReward}";
                    _dailyRewardView.TimerSlider.value =
                        (_dailyRewardView.TimeCooldown - (float) currentClaimCooldown.TotalSeconds) /
                        _dailyRewardView.TimeCooldown;
                }
            }

            for (var i = 0; i < _slots.Count; i++)
                _slots[i].SetData(_dailyRewardView.Rewards[i], i + 1, i == _dailyRewardView.CurrentSlotInActive);
        }

        private void SubscribeButtons()
        {
            _dailyRewardView.GetRewardButton.onClick.AddListener(ClaimReward);
            _dailyRewardView.ResetButton.onClick.AddListener(ResetTimer);
            _dailyRewardView.MenuButton.onClick.AddListener(BackToMainMenu);
        }

        private void ClaimReward()
        {
            if (!_isGetReward)
                return;

            var reward = _dailyRewardView.Rewards[_dailyRewardView.CurrentSlotInActive];

            switch (reward.RewardType)
            {
                case RewardType.Wood:
                    CurrencyView.Instance.AddWood(reward.CountCurrency);
                    break;
                case RewardType.Diamond:
                    CurrencyView.Instance.AddDiamonds(reward.CountCurrency);
                    break;
            }

            _dailyRewardView.TimeGetReward = DateTime.UtcNow;
            _dailyRewardView.CurrentSlotInActive =
                (_dailyRewardView.CurrentSlotInActive + 1) % _dailyRewardView.Rewards.Count;

            RefreshRewardsState();
        }

        private void ResetTimer()
        {
            PlayerPrefs.DeleteAll();
        }

        private void BackToMainMenu()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
        }
    }

}