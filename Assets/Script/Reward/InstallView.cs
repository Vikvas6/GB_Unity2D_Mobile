using UnityEngine;

namespace Game.Reward
{
    public class InstallView : MonoBehaviour
    {
        [SerializeField] private DailyRewardView _dailyRewardView;

        private DailyRewardController _dailyRewardController;

        private void Awake()
        {
            _dailyRewardController = new DailyRewardController(null, null);
        }

        private void Start()
        {
            _dailyRewardController.RefreshView();
        }
    }
}