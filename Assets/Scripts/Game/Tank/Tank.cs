using Game.ForcRotator;
using Game.Movement;
using Game.TankStateMMachine;
using Game.TankStateMMachine.TankStates;
using Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;
using Infrastructure.GameFactories;

namespace Game.Tank
{
    public class Tank : MonoBehaviour, IProgressSaver
    {

        [Inject] private readonly IGameFactory _gameFactory;
        public Mover Mover;
        public ForceRotator ForceRotator;
        public Death.Death Death;

        protected TankStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new TankStateMachine(this);
        }

        private void Start()
        {
            _stateMachine.ChangeState<MoveState>();
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TriggerEnter2DHandler(other);
        }

        protected virtual void TriggerEnter2DHandler(Collider2D other){}

        public virtual void Save(GameProgressData gameProgressData){}
        
        private void OnDestroy()
        {
            _gameFactory?.RemoveProgressSaver(this);
        }
    }
}
