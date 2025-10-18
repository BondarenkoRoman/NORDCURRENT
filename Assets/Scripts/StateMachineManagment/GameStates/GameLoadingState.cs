using System;
using Game.Tank;
using Infrastructure.AssetManagement;
using Infrastructure.GameFactories;
using StateMachineManagment.States;
using UnityEngine;
using Zenject;

namespace StateMachineManagment.GameStates
{
    public class GameLoadingState : IState
    {
        [Inject] private readonly IAssetProvider _assetProvider;
        [Inject] private readonly ISpawnService _spawnService;
        [Inject] private readonly IGameFactory _gameFactory;
        
        public void Enter()
        {
            _gameFactory.CreateEnvironment();
            _spawnService.CreateSpawners();
            CreatePlayer();
            CreateAITanks();// can spawn over player
        }

        private void CreatePlayer()
        {
            SpawnPoint spawnPoint = _spawnService.GetFreeSpawnPoint();
            if (spawnPoint != null)
            {
                var position = spawnPoint.transform.position;
                _gameFactory.CreatePlayerTank(position, 
                    Quaternion.AngleAxis(GetFacingAngle(position), Vector3.forward));
            }
        }

        private void CreateAITanks()
        {
            for (int i = 0; i < 4; i++)
            {
                SpawnPoint spawnPoint = _spawnService.GetFreeSpawnPoint();
                {
                    if (spawnPoint != null)
                    {
                        var position = spawnPoint.transform.position;
                        _gameFactory.CreateAITank(position, 
                            Quaternion.AngleAxis(GetFacingAngle(position), Vector3.forward));
                    }
                }
            }
        }
        
        private float GetFacingAngle(Vector3 spawnPosition)
        {
            Vector3 toCenter = Vector3.zero - spawnPosition;
            return Mathf.Atan2(toCenter.y, toCenter.x) * Mathf.Rad2Deg - 90;
        }

        public void Exit() { }
        
    }
}
