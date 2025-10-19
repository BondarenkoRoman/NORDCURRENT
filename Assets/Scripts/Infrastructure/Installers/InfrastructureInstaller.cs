using Infrastructure.AssetManagement;
using Infrastructure.GameFactories;
using Infrastructure.GameSession;
using Infrastructure.SaveLoad;
using Infrastructure.SpawnPointServicies;
using Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            CoroutineRunner();
            Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnPointService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameSessionService>().AsSingle();
        }

        private void CoroutineRunner()
        {
            var runnerGO = new GameObject("CoroutineRunner");
            var runner = runnerGO.AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(runnerGO);
            Container.Bind<CoroutineRunner>().FromInstance(runner).AsSingle();
        }
    }
}
