using ScriptableObjects;

namespace Infrastructure.StaticData
{
    public interface IStaticDataService : IInitialize.IInitialize
    {
        SpawnPointConfig SpawnPointConfig { get; }
    }
}
