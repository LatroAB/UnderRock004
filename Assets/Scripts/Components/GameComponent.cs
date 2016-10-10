using UnityEngine;
using System;
using System.Collections;

public interface IGameComponent
{
    Guid GetClassID();
    string GetComponentName();
}