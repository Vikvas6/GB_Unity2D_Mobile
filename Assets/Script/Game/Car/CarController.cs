using Tools;
using UnityEngine;

namespace Game
{
    internal sealed class CarController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};
        
        public CarController()
        {
            LoadView();
        }

        private CarView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }
    } 
}

