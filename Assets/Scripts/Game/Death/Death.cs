using System;
using UnityEngine;

namespace Game.Death
{
    public class Death : MonoBehaviour
    {
        public event Action Dead;

        public void Die()
        {
            Dead?.Invoke();
            Destroy(gameObject);
        }
    }
}
