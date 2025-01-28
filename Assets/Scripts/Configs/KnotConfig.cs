using System;
using UnityEngine;

[Serializable]
public class KnotConfig
{
    [field: SerializeField, Range(2, 4)] public int RopeCount { get; private set; }
}
