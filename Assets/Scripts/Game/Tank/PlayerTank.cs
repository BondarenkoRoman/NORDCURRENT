using Game.TankStateMMachine.TankStates;
using Infrastructure.Data;
using Infrastructure.GameSession;
using Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;

namespace Game.Tank
{
    public class PlayerTank : Tank
    {
        [Inject] private readonly IGameSessionService _gameSessionService;
        
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
                AngleRotation = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90f
            };
            Debug.LogError("Do player Save "+playerData.Position.X);
            _gameSessionService.GameProgressData.PlayerTankData = playerData;
            //gameProgressData.PlayerTankData = playerData;
        }
    }
}
