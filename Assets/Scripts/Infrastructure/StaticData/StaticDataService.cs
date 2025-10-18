using System.Collections;
using System.Collections.Generic;
using Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

public class StaticDataService : IStaticDataService
{
    [Inject] private readonly IAssetProvider _assets;
    public SpawnPointConfig SpawnPointConfig { get; private set; }

    //интерфейс под лоад, так надо надо будет для загрузки инфы из префсов
    public void Load()
    {
        SpawnPointConfig = Resources.Load<SpawnPointConfig>(AssetPath.SpawnPointsConfig);
    }

}
