using Infrastructure.GameFactories;
using UnityEngine;
using Zenject;

namespace Game.Shootin
{
    public class Shooting : MonoBehaviour
    {
        [Inject] private readonly IGameFactory _gameFactory;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private float reloadTime = 5.0f;
        private IShootingInput shootingInput;
        private float reloadTimer = 0f;
    
        private void Awake()
        {
            shootingInput = GetComponent<IShootingInput>();
        }

        private void Update()
        {
            ReloadingProcess();
        
            if(IsShotAvailable())
            {
                Shot();
                StartReload();
            }
        }

        private void ReloadingProcess()
        {
            if (reloadTimer > 0f)
            {
                reloadTimer -= Time.deltaTime;
            }
        }

        private bool IsShotAvailable()
        {
            return reloadTimer <= 0f && shootingInput.IsShooting;
        }

        private void Shot()
        {
            _gameFactory.CreateBullet(bulletSpawnPoint.transform.position, transform.rotation);
        }

        private void StartReload()
        {
            reloadTimer = reloadTime;
        }
    }
}
