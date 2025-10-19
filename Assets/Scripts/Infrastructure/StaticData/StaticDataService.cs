using Infrastructure.AssetManagement;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        [Inject] private readonly IAssetProvider _assets;
        public SpawnPointConfig SpawnPointConfig { get; private set; }
        public GameConfig GameConfig { get; private set; }
    
        public void Initialize()
        {
            SpawnPointConfig = _assets.Load<SpawnPointConfig>(AssetPath.SpawnPointsConfig);
            GameConfig = _assets.Load<GameConfig>(AssetPath.GameConfig);
            
        }

    }
}
