using System;
using System.Collections.Generic;
using StateMachineManagment.Factory;
using StateMachineManagment.GameStates;
using StateMachineManagment.States;
using Zenject;

namespace StateMachineManagment
{
    public class GameStateMachine : IInitializable, IStateSwitcher
    {
        [Inject] private readonly IStateFactory StateFactory;
        private Dictionary<Type, IState> States;
        private IState CurrentState;
    
        public void Initialize()
        {
            States = new Dictionary<Type, IState>
            {
                {typeof(BootstrapState), StateFactory.GetState<BootstrapState>()},
                {typeof(GameLoadingState), StateFactory.GetState<GameLoadingState>()},
            };

            SwitchState<BootstrapState>();
        }

        public void SwitchState<T>() where T : class, IState
        {
            if(CurrentState is T)
                return;
        
            if (States.TryGetValue(typeof(T), out IState state))
            {
                CurrentState?.Exit();
                CurrentState = state;
                CurrentState.Enter();
            }
        }
    }
}
