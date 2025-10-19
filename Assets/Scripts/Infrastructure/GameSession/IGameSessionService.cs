using Infrastructure.SaveLoad;

namespace Infrastructure.GameSession
{
    public interface IGameSessionService
    {
        public GameProgressData GameProgressData { get; set; }
    }
}