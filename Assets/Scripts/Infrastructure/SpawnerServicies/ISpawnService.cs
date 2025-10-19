using Game.SpawnerPoints;

namespace Infrastructure.SpawnerServicies
{
    public interface ISpawnService
    {
        public void CreateSpawners();
        SpawnPoint GetFreeSpawnPoint();
    }
}
