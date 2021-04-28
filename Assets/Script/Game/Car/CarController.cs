using Tools;
using Game.Features.Abilities;
using UnityEngine;
using Profile;

namespace Game
{
    public class CarController : BaseController, IAbilityActivator
    {
        #region Fields

        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};
        private readonly CarView _carView;
        private readonly ProfilePlayer _profilePlayer;

        #endregion
        
        #region Life cycle
        
        public CarController(ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _carView = LoadView();
        }
        
        #endregion

        #region Methods
        
        private CarView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }

        #endregion

        #region IAbilityActivator
        
        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }

        public ProfilePlayer GetProfilePlayer()
        {
            return _profilePlayer;
        }

        #endregion
    } 
}