namespace Game.Features.Abilities
{
    public class StubAbility : IAbility
    {
        public static readonly IAbility Default = new StubAbility();

        #region IAbility

        public void Apply(IAbilityActivator activator)
        {
        }
        
        #endregion
    }
}