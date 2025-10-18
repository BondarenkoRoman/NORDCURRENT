using System;
using Infrastructure.GameFactories;
using StateMachineManagment.States;
using UnityEngine;
using Zenject;

namespace StateMachineManagment.GameStates
{
    public class BootstrapState : IState
    {
        [Inject] private readonly IStateSwitcher _stateSwitcher;
        [Inject] private readonly IStaticDataService _staticDataService;
        
        public void Enter()
        {
            _staticDataService.Initialize();
            
            _stateSwitcher.SwitchState<GameLoadingState>();
        }

        public void Exit() { }
    }
}
