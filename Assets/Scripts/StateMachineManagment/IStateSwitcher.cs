using StateMachineManagment.States;

namespace StateMachineManagment
{
    public interface IStateSwitcher 
    {
        public void SwitchState<T>() where T : class, IState;
    }
}
