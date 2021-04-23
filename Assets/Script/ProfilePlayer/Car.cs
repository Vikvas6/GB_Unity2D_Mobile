using Game.Features;


namespace Profile
{
    public class Car : IUpgradable
    {
        #region Properties
      
        public float Speed { get; set; }
   
        #endregion
        
        #region Fields
      
        private readonly float _defaultSpeed;
   
        #endregion

        
        #region Life cycle
    
        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        #endregion
        

        #region IUpgradable

        public void Restore()
        {
            Speed = _defaultSpeed;
        }

        #endregion
    }
}

