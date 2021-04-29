using Tools;
using Game.Analytic;

namespace Profile
{
    public sealed class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        
        public IAnalyticTools AnalyticTools { get; }
        
        public ProfilePlayer(float speedCar, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = analyticTools;
        }
    }
}

