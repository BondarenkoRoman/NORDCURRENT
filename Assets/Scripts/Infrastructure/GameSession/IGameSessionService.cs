using Infrastructure.SaveLoad;

namespace Infrastructure.GameSession
{
    public interface IGameSessionService
    {
        GameProgressData GameProgressData { get; set; }
        void ClearProgressData();
    }
}