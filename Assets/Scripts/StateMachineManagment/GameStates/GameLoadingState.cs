using System;
using Infrastructure.AssetManagement;
using Infrastructure.GameFactories;
using StateMachineManagment.States;
using UnityEngine;
using Zenject;

namespace StateMachineManagment.GameStates
{
    public class GameLoadingState : IState
    {
        [Inject] private readonly IAssetProvider _assetProvider;
        
        public void Enter()
        {
            _assetProvider.Instantiate(AssetPath.Environment);

        }

        public void Exit() { }
    }
}
