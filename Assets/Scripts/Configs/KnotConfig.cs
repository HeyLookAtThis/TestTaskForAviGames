using System;
using UnityEngine;

[Serializable]
public class KnotConfig
{
    [field: SerializeField, Range(0, 13)] public int[] IndexesOfKnotToConnectTo { get; private set; }
}
