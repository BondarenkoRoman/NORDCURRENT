using StateMachineManagment.States;
using UnityEngine;
using Game.Obstaclies;
using Game.Tank;

namespace Game.TankStateMMachine.TankStates
{
    public class ForceRotatorState : IState, IUpdateable
    {
        private readonly Tank.Tank _tank;
        private readonly TankStateMachine _stateMachine;
        
        public ForceRotatorState(Tank.Tank tank, TankStateMachine stateMachine)
        {
            _tank = tank;
            _stateMachine = stateMachine;
        }

        public void Enter() 
        {
            _tank.ForceRotator.TurnAroundStart();
            _tank.ForceRotator.OnRotationFinished += OnRotationFinishedListener;
        }

        public void Exit() {}

        public void Update()
        {
            _tank.ForceRotator.TurnAroundProcess();
        }

        private void OnRotationFinishedListener()
        {
            if (_tank.ForceRotator.IsForwardWayBlocked())
            {
                _tank.ForceRotator.TurnAroundStart();
                return;
            }

            _tank.ForceRotator.OnRotationFinished -= OnRotationFinishedListener;
            _stateMachine.ChangeState<MoveState>();
        }
    }
}
