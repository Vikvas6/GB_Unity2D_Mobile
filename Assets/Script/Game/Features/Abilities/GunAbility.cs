using JetBrains.Annotations;
using Game.Item;
using UnityEngine;

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

        public void Apply(IAbilityActivator activator)
        {
            var projectile = Object.Instantiate(_config.view).GetComponent<Rigidbody2D>();
            projectile.AddForce(activator.GetViewObject().transform.right * _config.value, ForceMode2D.Force);
        }

        #endregion
    }
}