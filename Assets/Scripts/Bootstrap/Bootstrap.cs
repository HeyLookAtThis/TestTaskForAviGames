using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private KnotSpawner _spawner;
    [SerializeField] private Knot _knootPrefab;

    private KnotFactory _factory;

    private void Awake()
    {
        _factory = new KnotFactory(_knootPrefab);
        _spawner.InitializeFactory(_factory);
        _spawner.Run();
    }
}
