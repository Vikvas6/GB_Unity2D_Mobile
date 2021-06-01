using JetBrains.Annotations;
using Game.Item;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Features.Abilities
{
    public class GunAbility : IAbility
    {
        #region Fields

        private readonly AbilityItemConfig _config;

        #endregion

        #region Life cycle

        public GunAbility([NotNull] AbilityItemConfig config)
        {
            _config = config;
        }

        #endregion

        #region IAbility

        public void ApplyPrefab(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_config.view).GetComponent<Rigidbody2D>();
            //projectile.AddForce(activator.GetViewObject().transform.right * _config.value, ForceMode2D.Force);
            projectile.DOMove(new Vector2(_config.value, _config.additionalValue), _config.duration);
        }

        //Addressables
        public void Apply(IAbilityActivator activator)
        {
            Addressables.LoadAssetAsync<GameObject>(_config.viewReference).Completed += OnCompleted;
        }

        private void OnCompleted(AsyncOperationHandle<GameObject> obj)
        {
            var projectile = Object.Instantiate(obj.Result).GetComponent<Rigidbody2D>();
            projectile.DOMove(new Vector2(_config.value, _config.additionalValue), _config.duration);
            Addressables.Release(obj);
        }

        #endregion
    }
}