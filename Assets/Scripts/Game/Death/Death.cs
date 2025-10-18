using System;
using UnityEngine;

namespace Game.Death
{
    public class Death : MonoBehaviour
    {
        public event Action<Death> Dead;

        public void Die()
        {
            Dead?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
