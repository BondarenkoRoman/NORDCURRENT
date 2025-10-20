using System;
using UnityEngine;
using System.Linq;

namespace Game.ForcRotator
{
    public class ForceRotator : MonoBehaviour
    {
        [SerializeField] private float _turnAngularSpeedDeg = 360f;
        [SerializeField] private LayerMask _blockingMask;
        [SerializeField] private float _checkDistance = 1f;
        [SerializeField] private float _checkRadius = 0.45f;
        public event Action OnRotationFinished;
        private bool _isTurningAround;
        private float _turnTargetAngleDeg;


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
            OnRotationFinished.Invoke();
        }

        public bool IsForwardWayBlocked()
        {
            Vector2 checkPoint = transform.position + transform.up * _checkDistance;
            Collider2D[] overlaps = Physics2D.OverlapCircleAll(checkPoint, _checkRadius, _blockingMask);
            return overlaps.Any(col =>col != null &&
            (col.attachedRigidbody == null || col.attachedRigidbody.gameObject != gameObject));
        }
    }
}
