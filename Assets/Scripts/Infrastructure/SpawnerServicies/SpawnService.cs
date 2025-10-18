using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.GameFactories;
using UnityEngine;
using Zenject;

public class SpawnService : ISpawnService
{
    [Inject] private readonly IStaticDataService _staticDataService; 
    [Inject] private readonly IGameFactory _gameFactory; 
    private List<SpawnPoint> _spawnPoints = new ();
    
    public void CreateSpawners()
    {
        var spawnPointConfig = _staticDataService.SpawnPointConfig;
        foreach (var spawnPointPosition in spawnPointConfig.SpawnPointPositions)
        {
            _spawnPoints.Add(_gameFactory.CreateSpawnPoint(spawnPointPosition).GetComponent<SpawnPoint>());
        }
    }

    public SpawnPoint GetFreeSpawnPoint()
    {
        var freeSpawnPoints = _spawnPoints.Where(x => !x.Reserved).ToList();
        if (freeSpawnPoints.Count > 0)
        {
            var point = freeSpawnPoints[Random.Range(0, freeSpawnPoints.Count)];
            point.Reserved = true;
            return point;
        }

        return null;
    }
}
