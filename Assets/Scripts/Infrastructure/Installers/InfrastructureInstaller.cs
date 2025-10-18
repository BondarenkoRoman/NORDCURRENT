using Infrastructure.AssetManagement;
using Infrastructure.GameFactories;
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
        }
    }
}
