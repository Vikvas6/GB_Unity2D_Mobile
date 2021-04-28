using Game.Features;
using Tools;


namespace Profile
{
    public class Car : IUpgradable
    {
        #region Properties
      
        public SubscriptionProperty<float> Speed {get; set;} = new SubscriptionProperty<float>();
   
        #endregion
        
        #region Fields
      
        private readonly float _defaultSpeed;
   
        #endregion

        
        #region Life cycle
    
        public Car(float speed)
        {
            _defaultSpeed = speed;
            Speed.Value = speed;
            Restore();
        }

        #endregion
        

        #region IUpgradable

        public void Restore()
        {
            Speed.Value = _defaultSpeed;
        }

        #endregion
    }
}

