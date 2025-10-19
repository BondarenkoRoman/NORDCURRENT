using UnityEngine;

namespace Game.SpawnerPoints
{
    public class SpawnPoint : MonoBehaviour
    {
        public bool Reserved;

        private void OnTriggerStay2D(Collider2D other)
        {
            if(other.TryGetComponent<Tank.Tank>(out var tank))
            {
                Reserved = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.TryGetComponent<Tank.Tank>(out var tank))
            {
                Reserved = false;
            }
        }
    }
}
