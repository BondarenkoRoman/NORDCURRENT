
using StateMachineManagment.States;
using Zenject;

namespace StateMachineManagment.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) =>
            _container = container;

        public T GetState<T>() where T : class, IState =>
            _container.Resolve<T>();
    }
}
