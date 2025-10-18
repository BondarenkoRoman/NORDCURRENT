using UnityEngine;

namespace Infrastructure.GameFactories
{
    public interface IGameFactory
    {
        GameObject CreatePlayerTank();
        GameObject CreateAITank();
        GameObject CreateBullet();
        GameObject CreateEnvironment();
    }
}
