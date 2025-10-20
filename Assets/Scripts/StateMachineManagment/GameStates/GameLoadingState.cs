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
        [Inject] private readonly SpawnService _spawnService;
        
        public void Enter()
        {
            _gameFactory.CreateEnvironment();
            _spawnPointService.CreateSpawners();
            _spawnService.AddPlayer();
            _spawnService.AddAITanks();
        }

        public void Exit() { }
    }
}
