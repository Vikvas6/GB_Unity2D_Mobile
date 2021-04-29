using System.Collections.Generic;
using Game.Item;

namespace Game.Features.Abilities
{
    public class AbilityRepository : IRepository<int, IAbility>
    {
        #region Fields

        private readonly Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();

        #endregion

        #region Life cycle

        public AbilityRepository(
            List<AbilityItemConfig> itemConfigs)
        {
            PopulateItems(ref _abilityMapById, itemConfigs);
        }

        #endregion
        
        #region Methods

        private void PopulateItems(
            ref Dictionary<int, IAbility> upgradeHandlersMapByType,
            List<AbilityItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.Id)) continue;
                upgradeHandlersMapByType.Add(config.Id, CreateAbilityByType(config));
            }
        }

        private IAbility CreateAbilityByType(AbilityItemConfig config)
        {
            switch (config.type)
            {
                case AbilityType.Gun:
                    return new GunAbility(config);
                case AbilityType.SpeedUp:
                    return new RailingAbility(config);
                default:
                    return StubAbility.Default;
            }
        }
        
        #endregion

        #region IRepository

        public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapById;

        #endregion
        
    }
}