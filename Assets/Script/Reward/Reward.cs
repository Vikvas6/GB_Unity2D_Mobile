using System;
using UnityEngine;

namespace Game.Reward
{
    [Serializable]
    public class Reward
    {
        public RewardType RewardType;
        public Sprite IconCurrency;
        public int CountCurrency;
    }
}