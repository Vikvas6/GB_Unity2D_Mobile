using System;
using System.Collections.Generic;
using Game.Item;
using UnityEngine;

namespace Game.Features.Abilities
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {
        #region Fields
        
        [SerializeField] private RectTransform _itemsParent;
        [SerializeField] private AbilityItemView _abilityItemView;

        private IReadOnlyList<IItem> _abilityItems;
        
        #endregion

        #region Methods
        
        protected virtual void OnUseRequested(IItem e)
        {
            UseRequested?.Invoke(this, e);
        }

        #endregion

        #region IAbilityCollectionView

        public event EventHandler<IItem> UseRequested;
        
        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            _abilityItems = abilityItems;
        }

        public void Show()
        {
            foreach (IItem item in _abilityItems)
            {
                AbilityItemView itemView = Instantiate(_abilityItemView, _itemsParent);
                itemView.SetupItem(item, OnUseRequested);
            }
        }

        public void Hide()
        {
            // красиво спрятать какой-то объект
        }

        #endregion
    }
}