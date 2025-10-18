using System.Collections;
using System.Collections.Generic;
using Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

public class StaticDataService : IStaticDataService
{
    [Inject] private readonly IAssetProvider _assets;
    public SpawnPointConfig SpawnPointConfig { get; private set; }
    
    public void Initialize()
    {
        SpawnPointConfig = Resources.Load<SpawnPointConfig>(AssetPath.SpawnPointsConfig);
    }

}
