using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStaticDataService : IInitialize
{
    SpawnPointConfig SpawnPointConfig { get; }
}
