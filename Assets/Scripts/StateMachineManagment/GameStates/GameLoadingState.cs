using System;
using Game.SpawnerPoints;
using Infrastructure.AssetManagement;
using Infrastructure.GameFactories;
using Infrastructure.SpawnPointServicies;
using Infrastructure.SpawnService;
using StateMachineManagment.States;
using UnityEngine;
using Zenject;

namespace StateMachineManagment.GameStates
{
    public class GameLoadingState : IState
    {
        [Inject] private readonly IStateSwitcher _stateSwitcher;
        [Inject] private readonly ISpawnPointService _spawnPointService;
        [Inject] private readonly IGameFactory _gameFactory;
        [Inject] private readonly ISpawnService _spawnService;
        
        public void Enter()
        {
            _gameFactory.CreateEnvironment();
            _spawnPointService.CreateSpawners();
            _spawnService.AddPlayer();
            _spawnService.AddAITanks();
            
            _stateSwitcher.SwitchState<GameplayState>();
        }

        public void Exit() { }
    }
}
