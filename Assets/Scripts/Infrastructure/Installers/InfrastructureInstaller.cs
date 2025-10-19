using Infrastructure.AssetManagement;
using Infrastructure.GameFactories;
using Infrastructure.GameSession;
using Infrastructure.SaveLoad;
using Infrastructure.SpawnerServicies;
using Infrastructure.StaticData;
using Zenject;

namespace Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameSessionService>().AsSingle();
        }
    }
}
