using System.Collections.Generic;
using Infrastructure.SaveLoad;
using UnityEngine;

namespace Infrastructure.GameFactories
{
    public interface IGameFactory
    {
        GameObject CreatePlayerTank(Vector3 at, Quaternion quaternion);
        GameObject CreateAITank(Vector3 at, Quaternion quaternion);
        GameObject CreateBullet(Vector3 at, Quaternion quaternion);
        GameObject CreateEnvironment();
        public GameObject CreateSpawnPoint(Vector3 at);
        
        List<IProgressSaver> ProgressSavers { get; }
        void RemoveProgressSaver(IProgressSaver progressSaver);
    }
}
