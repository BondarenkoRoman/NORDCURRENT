using Game.Obstaclies;
using Game.Shootin;
using Game.TankStateMMachine.TankStates;
using Infrastructure.Data;
using Infrastructure.GameFactories;
using Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;

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
        
        public override void Save(GameProgressData gameProgressData)
        {
            TankPositionData aiTankData = new TankPositionData()
            {
                Position = transform.position.AsVectorData(),
                AngleRotation = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90f
            };
            gameProgressData.AiTanksData.Add(aiTankData);
        }
    }
}
