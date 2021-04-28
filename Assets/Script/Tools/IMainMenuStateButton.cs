using Profile;

namespace Tools
{
    public interface IMainMenuStateButton : IStateButton
    {
        GameState GameStateChanger { get; }
    }
}