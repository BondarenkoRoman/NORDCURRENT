using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnService
{
    public void CreateSpawners();
    SpawnPoint GetFreeSpawnPoint();
}
