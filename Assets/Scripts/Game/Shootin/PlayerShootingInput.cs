using UnityEngine;

namespace Game.Shootin
{
     public class PlayerShootingInput : MonoBehaviour, IShootingInput
     {
          public bool IsShootIing => Input.GetMouseButtonDown(0);
     }
}
