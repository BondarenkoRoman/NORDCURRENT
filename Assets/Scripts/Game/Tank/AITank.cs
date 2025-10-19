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
                Rotation = transform.eulerAngles.AsVectorData()
            };
            
            gameProgressData.AiTanksData.Add(aiTankData);
        }
        
    }
}
