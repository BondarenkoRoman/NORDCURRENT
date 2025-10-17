using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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
