using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.ForcRotator
{
    public class ForceRotator : MonoBehaviour
    {
        [SerializeField] private float _turnAngularSpeedDeg = 360f;
        [SerializeField] private float _turnAroundCooldown = 0.2f;

        private bool _isTurningAround;
        private float _turnTargetAngleDeg;
        private float _turnCooldownUntil;

        public event Action OnRotationFinished;

        public void TurnAroundStart()
        {
            if (_isTurningAround)
                return;

            _isTurningAround = true;
            float currentAngleDeg = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90f;
            _turnTargetAngleDeg = Mathf.Repeat(currentAngleDeg + 180f, 360f);
        }

        public void TurnAroundProcess()
        {
            float currentAngleDeg = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg - 90f;
            float maxStep = _turnAngularSpeedDeg * Time.deltaTime;
            float newAngleDeg = Mathf.MoveTowardsAngle(currentAngleDeg, _turnTargetAngleDeg, maxStep);
            transform.rotation = Quaternion.AngleAxis(newAngleDeg, Vector3.forward);

            if (Mathf.DeltaAngle(newAngleDeg, _turnTargetAngleDeg) == 0f)
            {
                TurnAroundFinish();
            }
        }

        private void TurnAroundFinish()
        {
            _isTurningAround = false;
            _turnCooldownUntil = Time.time + _turnAroundCooldown;
            OnRotationFinished.Invoke();
        }
    }
}
