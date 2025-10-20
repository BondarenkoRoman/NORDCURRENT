using UnityEngine;

namespace Game.Shootin
{
     public class PlayerShootingInput : MonoBehaviour, IShootingInput
     {
          public bool IsShooting => Input.GetMouseButtonDown(0);
     }
}
