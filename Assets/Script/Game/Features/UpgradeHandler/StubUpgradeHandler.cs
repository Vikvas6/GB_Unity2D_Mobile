namespace Game.Features
{
    public class StubUpgradeHandler : IUpgradeHandler
    {
        public static readonly IUpgradeHandler Default = new StubUpgradeHandler();
        
        #region IUpgradeHandler

        public IUpgradable Upgrade(IUpgradable upgradable)
        {
            return upgradable;
        }

        #endregion
    }
}