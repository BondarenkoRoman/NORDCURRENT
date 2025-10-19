using System.Collections;
using Game.SpawnerPoints;
using Game.Tank;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.GameFactories;
using Infrastructure.GameSession;
using Infrastructure.SpawnPointServicies;
using Infrastructure.StaticData;
using UnityEngine;
using Zenject;

public class SpawnService : ISpawnService
{
    [Inject] private readonly ISpawnPointService _spawnPointService;
    [Inject] private readonly IGameFactory _gameFactory;
    [Inject] private readonly CoroutineRunner _coroutineRunner;
    [Inject] private readonly IStaticDataService _staticDataService;
    [Inject] private readonly IGameSessionService _gameSessionService;
    
    public void AddPlayer()
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;
        var tankData = _gameSessionService.GameProgressData.PlayerTankData;
        bool containsTankData = _gameSessionService.GameProgressData.PlayerTankData != null;
        
        if (containsTankData)
        {
            spawnPosition = tankData.Position.AsUnityVector();
            spawnRotation = Quaternion.AngleAxis(tankData.AngleRotation, Vector3.forward);
        }
        else
        {
            var spawnData = GetSpawnData();
            if (!spawnData.HasValue) return;
            
            spawnPosition = spawnData.Value.position;
            spawnRotation = spawnData.Value.rotation;
        }
        
        var tankGo = _gameFactory.CreatePlayerTank(spawnPosition, spawnRotation);
        SetupTank(tankGo, () => _coroutineRunner.Run(RespawnPlayer()));
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(_staticDataService.GameConfig.RespawnDelay);
        AddPlayer();
    }
    
    public void AddAITanks()
    {
        for (int i = 0; i < _staticDataService.GameConfig.EnemyCount; i++)
        {
            AddAITank();
        }
    }

    private void AddAITank()
    {
        var spawnData = GetSpawnData();
        if (spawnData.HasValue)
        {
            var tankGo = _gameFactory.CreateAITank(spawnData.Value.position, spawnData.Value.rotation);
            SetupTank(tankGo, () => _coroutineRunner.Run(RespawnAITank()));
        }
    }

    private IEnumerator RespawnAITank()
    {
        yield return new WaitForSeconds(_staticDataService.GameConfig.RespawnDelay);
        AddAITank();
    }

    private (Vector3 position, Quaternion rotation)? GetSpawnData()
    {
        SpawnPoint spawnPoint = _spawnPointService.GetFreeSpawnPoint();
        if (spawnPoint == null) return null;
        
        var position = spawnPoint.transform.position;
        var rotation = Quaternion.AngleAxis(LookAtCenterAngle(position), Vector3.forward);
        return (position, rotation);
    }

    private void SetupTank(GameObject tankGo, System.Action onDeadCallback)
    {
        var tank = tankGo.GetComponent<Tank>();
        tank.Dead += onDeadCallback;
    }

    private float LookAtCenterAngle(Vector3 spawnPosition)
    {
        Vector3 toCenter = Vector3.zero - spawnPosition;
        return Mathf.Atan2(toCenter.y, toCenter.x) * Mathf.Rad2Deg - 90;
    }
}
