namespace Game.Features
{
    public class SpeedUpgradeHandler : IUpgradeHandler
    {
        #region Fields
        
        private readonly float _speed;
        
        #endregion


        #region Life cycle

        public SpeedUpgradeHandler(float speed)
        {
            _speed = speed;
        }

        #endregion
        

        #region IUpgradeHandler
        
        public IUpgradable Upgrade(IUpgradable upgradable)
        {
            upgradable.Speed = _speed;
            return upgradable;
        }

        #endregion
    }
}