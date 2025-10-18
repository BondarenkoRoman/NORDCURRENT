using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = nameof(SpawnPointConfig), menuName = "ScriptableObjects/SpawnPointConfig")]
public class SpawnPointConfig : ScriptableObject
{
    public List<Vector3> SpawnPointPositions;
}
