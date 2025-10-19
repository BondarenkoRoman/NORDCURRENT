using Game.TankStateMMachine.TankStates;
using Infrastructure.Data;
using Infrastructure.SaveLoad;
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

        public override void Save(GameProgressData gameProgressData)
        {
            TankPositionData playerData = new TankPositionData()
            {
                Position = transform.position.AsVectorData(),
                Rotation = transform.eulerAngles.AsVectorData()
            };
            gameProgressData.PlayerTankData = playerData;
        }
    }
}
