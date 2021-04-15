using Profile;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal sealed class InputGameController : BaseController
    {
        private readonly ResourcePath _viewPathEndless = new ResourcePath {PathResource = "Prefabs/endlessMove"};
        private readonly ResourcePath _viewPathTape = new ResourcePath {PathResource = "Prefabs/tapeInputView"};
        private readonly ResourcePath _viewPathSwipe = new ResourcePath {PathResource = "Prefabs/swipeInputView"};
        private readonly BaseInputView _view;
        
        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            // _view = LoadView(_viewPathEndless);
            // _view.Init(leftMove, rightMove, car.Speed);
            // _view = LoadView(_viewPathSwipe);
            // _view.Init(leftMove, rightMove, car.Speed);
            _view = LoadView(_viewPathTape);
            _view.Init(leftMove, rightMove, car.Speed*10);
        }

        private BaseInputView LoadView(ResourcePath path)
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(path));
            AddGameObjects(objView);
            return objView.GetComponent<BaseInputView>();
        }
    } 
}

