using UnityEngine;

namespace Game.Movement
{
    public class PlayerMoveInput : MonoBehaviour, IMoveInput
    {
        public float GetMoveInput()
        {
            float moveInput = 0f;
            if (Input.GetKey(KeyCode.W)) moveInput += 1f;
            if (Input.GetKey(KeyCode.S)) moveInput -= 1f;
            return moveInput;
        }

        public float GetRotateInput()
        {
            float rotateInput = 0f;
            if (Input.GetKey(KeyCode.A)) rotateInput += 1f; 
            if (Input.GetKey(KeyCode.D)) rotateInput -= 1f; 
            return rotateInput;
        }
    }
}
