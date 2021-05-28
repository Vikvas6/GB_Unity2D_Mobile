using UnityEngine;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "Ability item", menuName = "Ability item", order = 0)]
    public class AbilityItemConfig : ScriptableObject
    {
        public ItemConfig itemConfig;
        public GameObject view;
        public AbilityType type;
        public float value;
        public float additionalValue;
        public float duration;

        public int Id => itemConfig.id;
    }
    
    public enum AbilityType
    {
        None,
        Gun,
        SpeedUp
    }
}