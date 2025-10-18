using UnityEngine;

namespace Game.Movement
{
    public class AIMoveInput : MonoBehaviour, IMoveInput
    {
        [SerializeField] private float _minChangeInterval = 1.5f;
        [SerializeField] private float _maxChangeInterval = 3.5f;

        private Vector2 _desiredDirection = Vector2.up;
        private float _nextDirectionChangeTime;

        private float _currentMoveInput;
        private float _currentRotateInput;

        public float GetMoveInput() => _currentMoveInput;

        public float GetRotateInput() => _currentRotateInput;

        private void OnEnable()
        {
            ScheduleNextDirectionChange();
            _desiredDirection = transform.up;
        }

        private void Update()
        {
            UpdateDirectionChange();
            SetMovementInput();
            UpdateRotateInput();
        }

        private void UpdateDirectionChange()
        {
            if (Time.time >= _nextDirectionChangeTime)
            {
                _desiredDirection = RandomDirection();
                ScheduleNextDirectionChange();
            }
        }

        private void SetMovementInput()
        {
            _currentMoveInput = 1f;
        }

        private void UpdateRotateInput()
        {
            float currentAngleDeg = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90f;
            float targetAngleDeg = Mathf.Atan2(_desiredDirection.y, _desiredDirection.x) * Mathf.Rad2Deg - 90f;
            float angleDifference = Mathf.DeltaAngle(currentAngleDeg, targetAngleDeg);
            _currentRotateInput = Mathf.Sign(angleDifference);
        }


        private void ScheduleNextDirectionChange()
        {
            float interval = Random.Range(_minChangeInterval, Mathf.Max(_minChangeInterval, _maxChangeInterval));
            _nextDirectionChangeTime = Time.time + interval;
        }

        private Vector2 RandomDirection()
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
            return direction;
        }
    }
}
