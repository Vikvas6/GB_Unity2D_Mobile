using System;
using System.Collections.Generic;
using Game.Item;
using Game.UI;
using UnityEngine;


namespace Game.Features.Abilities
{
    public interface IAbility
    {
        void Apply(IAbilityActivator activator);
    }

    public interface IAbilityActivator
    {
        GameObject GetViewObject();
    }
    
    public interface IAbilityCollectionView : IView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
    
    public interface IAbilitiesController
    {
        void ShowAbilities();
    }
}