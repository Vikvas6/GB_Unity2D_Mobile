using System.Collections.Generic;
using Game.Item;


namespace Game.Item
{
    public class ItemsRepository : BaseController, IRepository<int, IItem>
    {
        public IReadOnlyDictionary<int, IItem> Collection => _itemsMapById;
        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        #region Life cycle

        public ItemsRepository(
            List<ItemConfig> itemConfigs)
        {
            PopulateItems(ref _itemsMapById, itemConfigs);
        }
        
        protected override void OnDispose()
        {
            _itemsMapById.Clear();
            _itemsMapById = null;
        }

        #endregion
        
        
        #region Methods

        private void PopulateItems(
            ref Dictionary<int, IItem> upgradeHandlersMapByType,
            List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.id)) continue;
                upgradeHandlersMapByType.Add(config.id, CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                Id = config.id,
                Info = new ItemInfo { Title = config.title}
            };
        }
        
        #endregion
    }
}