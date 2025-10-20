using System.Collections;
using Game.SpawnerPoints;
using Game.TankBehaviour;
using Infrastructure.Data;
using Infrastructure.GameFactories;
using Infrastructure.GameSession;
using Infrastructure.SpawnPointServicies;
using Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.SpawnService
{
    public class SpawnService : ISpawnService
    {
        [Inject] private readonly ISpawnPointService _spawnPointService;
        [Inject] private readonly IGameFactory _gameFactory;
        [Inject] private readonly CoroutineRunner _coroutineRunner;
        [Inject] private readonly IStaticDataService _staticDataService;
        [Inject] private readonly IGameSessionService _gameSessionService;
    
        public void AddPlayer()
        {
            if (_gameSessionService.GameProgressData.IsPlayerTankDataValid())
            {
                AddPlayerAtSavedPoint();
            }
            else
            {
                AddPlayerAtSpawnPoint();
            }
        }

        private IEnumerator RespawnPlayer()
        {
            yield return new WaitForSeconds(_staticDataService.GameConfig.RespawnDelay);
            AddPlayerAtSpawnPoint();
        }

        private void AddPlayerAtSpawnPoint()
        {
            var spawnData = GetSpawnData();
            if (!spawnData.HasValue) return;
        
            var tankGo = _gameFactory.CreatePlayerTank(spawnData.Value.position, spawnData.Value.rotation);
            SetupTank(tankGo, () => _coroutineRunner.Run(RespawnPlayer()));
        }

        private void AddPlayerAtSavedPoint()
        {
            var tankData = _gameSessionService.GameProgressData.PlayerTankData;
            Vector3 spawnPosition = tankData.Position.AsUnityVector();
            Quaternion spawnRotation = Quaternion.AngleAxis(tankData.AngleRotation, Vector3.forward);
            var tankGo = _gameFactory.CreatePlayerTank(spawnPosition, spawnRotation);
            SetupTank(tankGo, () => _coroutineRunner.Run(RespawnPlayer()));
        }
    
        public void AddAITanks()
        {
            int enemyCount = _staticDataService.GameConfig.EnemyCount;
            int savedTanksCount = _gameSessionService.GameProgressData.AiTanksData.Count;
        
            for (int i = 0; i < Mathf.Min(enemyCount, savedTanksCount); i++)
                AddAITankFromSave(i);
            for (int i = savedTanksCount; i < enemyCount; i++)
                AddAITank();
        }

        private void AddAITankFromSave(int index)
        {
            var tankData = _gameSessionService.GameProgressData.AiTanksData[index];
            Vector3 spawnPosition = tankData.Position.AsUnityVector();
            Quaternion spawnRotation = Quaternion.AngleAxis(tankData.AngleRotation, Vector3.forward);
        
            var tankGo = _gameFactory.CreateAITank(spawnPosition, spawnRotation);
            SetupTank(tankGo, () => _coroutineRunner.Run(RespawnAITank()));
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
}
