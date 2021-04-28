using System;
using Game.Item;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.Abilities
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ItemConfig _activeItemConfig;

        private EventHandler<IItem> _useRequested;
        private IItem _activeItem;
        
        public void Init(EventHandler<IItem> useRequested)
        {
            _useRequested = useRequested;

            _activeItem = CreateItem(_activeItemConfig);
            
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _useRequested.Invoke(this, _activeItem);
        }
        
        private IItem CreateItem(ItemConfig config)
        {
            return new Item.Item
            {
                Id = config.id,
                Info = new ItemInfo {Title = config.title}
            };
        }
    }
}