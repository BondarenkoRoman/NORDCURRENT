using Game.Obstaclies;
using Game.TankBehaviour;
using UnityEngine;

namespace Game.Shootin
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float Speed;
    
        private void Update()
        {
            transform.position += transform.up * Speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Obstacle>(out var obstacle) ||
                other.TryGetComponent<Tank>(out var tank))
            {
                Destroy(gameObject);
            }
        }
    }
}
