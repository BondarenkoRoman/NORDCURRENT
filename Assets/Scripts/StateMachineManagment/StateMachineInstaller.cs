using StateMachineManagment.Factory;
using StateMachineManagment.GameStates;
using Zenject;

namespace StateMachineManagment
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStates();
            BindFactory();
            BindStateMachine();
        }

        private void BindStates()
        {
            Container.Bind<BootstrapState>().AsSingle().NonLazy();
            Container.Bind<GameLoadingState>().AsSingle().NonLazy();
        }
    
        private void BindFactory()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }
    }
}
