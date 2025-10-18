using StateMachineManagment.States;

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
            _tank.ForceRotator.OnRotationFinished -= OnRotationFinishedListener;
            _stateMachine.ChangeState<MoveState>();
        }
    }
}
