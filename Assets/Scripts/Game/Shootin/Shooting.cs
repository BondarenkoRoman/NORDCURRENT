using UnityEngine;

namespace Game.Shootin
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
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
        
            if(IsShotAvaliable())
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

        private bool IsShotAvaliable()
        {
            return reloadTimer <= 0f && shootingInput.IsShootIing;
        }

        private void Shot()
        {
            Instantiate(_bullet, bulletSpawnPoint.transform.position, transform.rotation);
        }

        private void StartReload()
        {
            reloadTimer = reloadTime;
        }
    }
}
