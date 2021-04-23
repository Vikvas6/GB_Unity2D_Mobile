using UnityEngine;

namespace Game.Item
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public int id;
        public string title;
    }
}