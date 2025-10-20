using System;
using System.Collections.Generic;
using Game.TankBehaviour;
using Game.TankStateMMachine.TankStates;
using StateMachineManagment.States;

namespace Game.TankStateMMachine
{
    public class TankStateMachine
    {
        private Dictionary<Type, IState> States;
        private IState _activeState;
    
        public TankStateMachine(Tank tank)
        {
            States = new Dictionary<Type, IState>()
            {
                {typeof(MoveState), new MoveState(tank)},
                {typeof(ForceRotatorState), new ForceRotatorState(tank, this)},
                {typeof(DeathState), new DeathState(tank)},
            };
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
                updateableState.Update();
        }

        public void ChangeState<T>() where T : class, IState
        {
            if (_activeState is T)
                return;

            if (States.TryGetValue(typeof(T), out var newState))
            {
                _activeState?.Exit();
                _activeState = newState;
                _activeState.Enter();
            }
        }
    }
}
