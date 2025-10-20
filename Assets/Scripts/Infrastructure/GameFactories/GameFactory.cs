using System.Collections.Generic;
using Infrastructure.AssetManagement;
using Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameFactories
{
    public class GameFactory : IGameFactory
    {
        [Inject] private readonly IAssetProvider _assets;
        [Inject] private DiContainer Container;

        public List<IProgressSaver> ProgressSavers { get; } = new ();

        public GameObject CreatePlayerTank(Vector3 at, Quaternion quaternion)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.PlayerTank, at, quaternion);
            Container.InjectGameObject(gameObject);
            ProgressSavers.Add(gameObject.GetComponent<IProgressSaver>());
            return gameObject;
        }
        
        public GameObject CreateAITank(Vector3 at, Quaternion quaternion)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.AITank, at, quaternion);
            Container.InjectGameObject(gameObject);
            ProgressSavers.Add(gameObject.GetComponent<IProgressSaver>());
            return gameObject;
        }

        public GameObject CreateBullet(Vector3 at, Quaternion quaternion)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.Bullet, at, quaternion);
            Container.InjectGameObject(gameObject);
            return gameObject;
        }
        
        public GameObject CreateEnvironment()
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.Environment);
            Container.InjectGameObject(gameObject);
            return gameObject;
        }
        
        public GameObject CreateSpawnPoint(Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(AssetPath.SpawnPoint, at);
            Container.InjectGameObject(gameObject);
            return gameObject;
        }
        
        public void RemoveProgressSaver(IProgressSaver progressSaver)
        {
            ProgressSavers.Remove(progressSaver);
        }
    }
}
