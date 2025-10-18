using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public event Action<Death> Dead;

    public void Die()
    {
        Dead.Invoke(this);
        Destroy(gameObject);
    }
}
