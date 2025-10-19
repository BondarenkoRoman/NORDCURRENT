using Game.SpawnerPoints;

namespace Infrastructure.SpawnPointServicies
{
    public interface ISpawnPointService
    {
        public void CreateSpawners();
        SpawnPoint GetFreeSpawnPoint();
    }
}
