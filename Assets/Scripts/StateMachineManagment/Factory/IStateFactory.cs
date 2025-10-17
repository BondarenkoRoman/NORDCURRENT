using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateFactory
{
    T GetState<T>() where T : class, IState;
}
