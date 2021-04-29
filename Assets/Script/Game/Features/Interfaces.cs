using Tools; 

namespace Game.Features
{
    public interface IShedController
    {
        void Enter();
        void Exit();
    }
    
    public interface IUpgradeHandler
    {
        IUpgradable Upgrade(IUpgradable upgradable);
    }

    public interface IUpgradable
    {
        void Restore();
        SubscriptionProperty<float> Speed { get; set; }
    }
}