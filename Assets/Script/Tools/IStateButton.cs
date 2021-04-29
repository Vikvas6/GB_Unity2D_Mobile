using System;
using Profile;


namespace Tools
{
    public interface IStateButton
    {
        void AddListener(Action<GameState> action);
        void RemoveListener(Action<GameState> action);
    }
}