using Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameFactories
{
    public class GameFactory : IGameFactory
    {
        [Inject] private readonly IAssetProvider _assets;

        public GameObject CreatePlayerTank(Vector3 at, Quaternion quaternion)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.PlayerTank, at, quaternion);
            return gameObject;
        }
        
        public GameObject CreateAITank(Vector3 at, Quaternion quaternion)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.AITank, at, quaternion);
            return gameObject;
        }

        public GameObject CreateBullet()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.Bullet);
            return gameObject;
        }
        
        public GameObject CreateEnvironment()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.Environment);
            return gameObject;
        }
        
        public GameObject CreateSpawnPoint(Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.SpawnPoint, at);
            return gameObject;
        }
    }
}
