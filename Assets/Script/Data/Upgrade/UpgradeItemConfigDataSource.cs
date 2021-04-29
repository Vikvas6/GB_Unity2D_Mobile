using UnityEngine;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource", order = 0)]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        public UpgradeItemConfig[] itemConfigs;
    }
}