using System;
using Infrastructure.GameFactories;
using Infrastructure.SaveLoad;
using Infrastructure.StaticData;
using StateMachineManagment.States;
using UnityEngine;
using Zenject;

namespace StateMachineManagment.GameStates
{
    public class BootstrapState : IState
    {
        [Inject] private readonly IStateSwitcher _stateSwitcher;
        [Inject] private readonly IStaticDataService _staticDataService;
        [Inject] private readonly ISaveLoadService _saveLoadService;
        
        public void Enter()
        {
            _staticDataService.Initialize();
            _saveLoadService.Initialize();
            
            _stateSwitcher.SwitchState<GameLoadingState>();
        }

        public void Exit() { }
    }
}
