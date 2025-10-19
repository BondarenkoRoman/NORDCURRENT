using System;
using Game.SpawnerPoints;
using Game.Tank;
using Infrastructure.AssetManagement;
using Infrastructure.GameFactories;
using Infrastructure.SpawnPointServicies;
using StateMachineManagment.States;
using UnityEngine;
using Zenject;

namespace StateMachineManagment.GameStates
{
    public class GameLoadingState : IState
    {
        [Inject] private readonly ISpawnPointService _spawnPointService;
        [Inject] private readonly IGameFactory _gameFactory;
        
        public void Enter()
        {
            _gameFactory.CreateEnvironment();
            _spawnPointService.CreateSpawners();
            AddPlayer();
            AddAITanks();
        }

        private void AddPlayer()
        {
            SpawnPoint spawnPoint = _spawnPointService.GetFreeSpawnPoint();
            if (spawnPoint != null)
            {
                var position = spawnPoint.transform.position;
                _gameFactory.CreatePlayerTank(position, 
                    Quaternion.AngleAxis(LookAtCenterAngle(position), Vector3.forward));
            }
        }

        private void AddAITanks()
        {
            for (int i = 0; i < 4; i++)
            {
                SpawnPoint spawnPoint = _spawnPointService.GetFreeSpawnPoint();
                if (spawnPoint != null)
                {
                    var position = spawnPoint.transform.position;
                    _gameFactory.CreateAITank(position, 
                        Quaternion.AngleAxis(LookAtCenterAngle(position), Vector3.forward));
                }
            }
        }
        
        private float LookAtCenterAngle(Vector3 spawnPosition)
        {
            Vector3 toCenter = Vector3.zero - spawnPosition;
            return Mathf.Atan2(toCenter.y, toCenter.x) * Mathf.Rad2Deg - 90;
        }

        public void Exit() { }
    }
}
