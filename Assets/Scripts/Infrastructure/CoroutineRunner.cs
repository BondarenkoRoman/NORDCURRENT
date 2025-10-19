using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class CoroutineRunner : MonoBehaviour
    {
        public Coroutine Run(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void Stop(Coroutine coroutine)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
        }
    }
}
