using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.TapeBackground
{
    internal sealed class TapeBackgroundController : BaseController
    {
        //private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/background"};
        private TapeBackgroundView _view;
        private SubscriptionProperty<float> _diff;
        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;
        
        public TapeBackgroundController(IReadOnlySubscriptionProperty<float> leftMove, 
            IReadOnlySubscriptionProperty<float> rightMove)
        {
            LoadViewAddressables();
            
            _leftMove = leftMove;
            _rightMove = rightMove;
            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscriptionOnChange(Move);
            _rightMove.UnSubscriptionOnChange(Move);
            base.OnDispose();
        }

        /*private TapeBackgroundView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<TapeBackgroundView>();
        }*/

        private void LoadViewAddressables()
        {
            Addressables.LoadAssetAsync<GameObject>("Background").Completed += OnAddressablesCompleted;
        }

        private void OnAddressablesCompleted(AsyncOperationHandle<GameObject> obj)
        {
            GameObject objView = Object.Instantiate(obj.Result);
            AddGameObjects(objView);
            Addressables.Release(obj);
            _view = objView.GetComponent<TapeBackgroundView>();
            _diff = new SubscriptionProperty<float>();
            _view.Init(_diff);
        }

        private void Move(float value)
        {
            _diff.Value = value;
        }
    }
}

