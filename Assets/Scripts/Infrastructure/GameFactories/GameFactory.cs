using Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameFactories
{
    public class GameFactory : IGameFactory
    {
        [Inject] private readonly IAssetProvider _assets;

        public GameObject CreatePlayerTank()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.PlayerTank);
            return gameObject;
        }
        
        public GameObject CreateAITank()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.AITank);
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
    }
}
