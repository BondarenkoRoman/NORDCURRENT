using StateMachineManagment.States;

namespace StateMachineManagment.Factory
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IState;
    }
}
