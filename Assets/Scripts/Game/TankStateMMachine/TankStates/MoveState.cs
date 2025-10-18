using StateMachineManagment.States;

namespace Game.TankStateMMachine.TankStates
{
    public class MoveState : IState, IUpdateable
    {
        private readonly Tank.Tank _tank;
        public MoveState(Tank.Tank tank)
        {
            _tank = tank;
        }
        public void Enter(){}

        public void Exit(){}

        public void Update()
        {
            _tank.Mover.Movement();
        }
    }
}
