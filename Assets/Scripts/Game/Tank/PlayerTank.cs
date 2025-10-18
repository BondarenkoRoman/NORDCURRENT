using Game.TankStateMMachine.TankStates;
using UnityEngine;

namespace Game.Tank
{
    public class PlayerTank : Tank
    {
        protected override void TriggerEnter2DHandler(Collider2D other)
        {
            if (other.TryGetComponent<Tank>(out var Tank))
            {
                _stateMachine.ChangeState<DeathState>();
            }
        }
    }
}
