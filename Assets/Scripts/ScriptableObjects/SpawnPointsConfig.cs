using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(SpawnPointConfig), menuName = "ScriptableObjects/SpawnPointConfig")]
    public class SpawnPointConfig : ScriptableObject
    {
        public List<Vector3> SpawnPointPositions;
    }
}
