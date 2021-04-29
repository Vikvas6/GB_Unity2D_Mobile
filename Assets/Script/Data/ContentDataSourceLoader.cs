using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Game.Item
{
    public static class ContentDataSourceLoader
    {
        public static List<UpgradeItemConfig> LoadUpgradeItemConfigs(ResourcePath resourcePath)
        {
            var config = ResourceLoader.LoadObject<UpgradeItemConfigDataSource>(resourcePath);
            return config == null ? new List<UpgradeItemConfig>() : config.itemConfigs.ToList();
        }
        
        public static List<AbilityItemConfig> LoadAbilityItemConfigs(ResourcePath resourcePath)
        {
            var config = ResourceLoader.LoadObject<AbilityItemConfigDataSource>(resourcePath);
            return config == null ? new List<AbilityItemConfig>() : config.itemConfigs.ToList();
        }
    }
}