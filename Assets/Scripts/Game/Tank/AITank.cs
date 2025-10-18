using Game.Obstaclies;
using Game.Shootin;
using Game.TankStateMMachine.TankStates;
using UnityEngine;

namespace Game.Tank
{
    public class AITank : Tank
    {
        protected override void TriggerEnter2DHandler(Collider2D other)
        {
            if (other.TryGetComponent<Tank>(out var tank) ||
                other.TryGetComponent<Obstacle>(out var Obstacle))
            {
                Debug.LogError("ForceRotaroTrigger");
                _stateMachine.ChangeState<ForceRotatorState>();
            }

            if (other.TryGetComponent<Bullet>(out var bullet))
            {
                _stateMachine.ChangeState<DeathState>();
            }
        }
    }
}
