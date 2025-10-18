using StateMachineManagment.States;

namespace Game.TankStateMMachine.TankStates
{
    public class DeathState : IState
    {
        private readonly Tank.Tank _tank;

        public DeathState(Tank.Tank tank)
        {
            _tank = tank;
        }
        public void Enter() 
        { 
            _tank.Death.Die();
        }

        public void Exit() {}
    }
}
