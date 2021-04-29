using UnityEngine;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "AbilityItemConfigDataSource", menuName = "AbilityItemConfigDataSource", order = 0)]
    public class AbilityItemConfigDataSource : ScriptableObject
    {
        public AbilityItemConfig[] itemConfigs;
    }
}