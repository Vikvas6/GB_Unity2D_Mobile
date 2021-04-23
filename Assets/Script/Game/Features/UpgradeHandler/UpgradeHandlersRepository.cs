using System.Collections.Generic;
using Game.Item;


namespace Game.Features
{
    public class UpgradeHandlersRepository : IRepository<int, IUpgradeHandler>
    {
        #region Fields
        
        private readonly Dictionary<int, IUpgradeHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeHandler>();

        #endregion
        
        #region Life cycle

        public UpgradeHandlersRepository(
            List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
        }
        
        #endregion
        
        #region Methods

        private void PopulateItems(
            ref Dictionary<int, IUpgradeHandler> upgradeHandlersMapByType,
            List<UpgradeItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.Id)) continue;
                upgradeHandlersMapByType.Add(config.Id, CreateHandlerByType(config));
            }
        }

        private IUpgradeHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.type)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeHandler(config.value);
                default:
                    return StubUpgradeHandler.Default;
            }
        }
        
        #endregion

        #region IRepository

        public IReadOnlyDictionary<int, IUpgradeHandler> Collection => _upgradeItemsMapById;

        #endregion
    }
}