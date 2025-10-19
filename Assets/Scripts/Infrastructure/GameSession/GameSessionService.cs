using Infrastructure.SaveLoad;

namespace Infrastructure.GameSession
{
    public class GameSessionService : IGameSessionService
    {
        public GameProgressData GameProgressData { get; set; } = new GameProgressData();
    }
}
