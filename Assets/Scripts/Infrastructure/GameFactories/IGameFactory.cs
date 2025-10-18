using UnityEngine;

namespace Infrastructure.GameFactories
{
    public interface IGameFactory
    {
        GameObject CreatePlayerTank(Vector3 at, Quaternion quaternion);
        GameObject CreateAITank(Vector3 at, Quaternion quaternion);
        GameObject CreateBullet();
        GameObject CreateEnvironment();
        public GameObject CreateSpawnPoint(Vector3 at);
    }
}
