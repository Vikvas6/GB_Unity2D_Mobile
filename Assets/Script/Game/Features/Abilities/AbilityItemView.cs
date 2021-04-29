using UnityEngine;
using UnityEngine.UI;
using Game.Item;
using System;

namespace Game.Features.Abilities
{
    public class AbilityItemView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _itemText;

        public void SetupItem(IItem item, Action<IItem> Use)
        {
            _itemText.text = item.Info.Title;
            _button.onClick.AddListener(() => Use.Invoke(item));
        }
    }
}
