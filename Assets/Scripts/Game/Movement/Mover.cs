using UnityEngine;

namespace Game.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] protected float _turnRadius = 2f;
        [SerializeField] private float _speed = 5f;
        protected IMoveInput moveInput;

        protected Vector2 Forward => transform.up;
    
        protected virtual void Awake()
        {
            moveInput = GetComponent<IMoveInput>();
        }

        public void Movement()
        {
            float rotateInput = this.moveInput.GetRotateInput();
            float moveInput = this.moveInput.GetMoveInput();

            Rotate(rotateInput);
            Move(moveInput);
        }

        private void Move(float moveInput)
        {
            if (Mathf.Abs(moveInput) > 0f)
            {
                Vector3 dir = Forward * Mathf.Sign(moveInput);
                float moveStep = _speed * Time.deltaTime;

                int obstacleMask = LayerMask.GetMask("Water");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, moveStep + 0.1f, obstacleMask);

                if (hit.collider == null)
                {
                    transform.position += dir * moveStep;
                }
            }
        }

        private void Rotate(float rotateInput)
        {
            float maxAngularSpeedRad = _speed / _turnRadius;
            float maxAngularStepDeg = Mathf.Rad2Deg * maxAngularSpeedRad * Time.deltaTime;
            if (Mathf.Abs(rotateInput) > 0f)
            {
                float currentAngleDeg = Mathf.Atan2(Forward.y, Forward.x) * Mathf.Rad2Deg - 90f;
                float signedStep = Mathf.Sign(rotateInput) * maxAngularStepDeg;
                float newAngleDeg = currentAngleDeg + signedStep;
                transform.rotation = Quaternion.AngleAxis(newAngleDeg, Vector3.forward);
            }
        }
    }
}


