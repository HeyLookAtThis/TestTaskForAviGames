using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawner : MonoBehaviour
{
    [SerializeField] private RopesConfig _config;
    [SerializeField] private KnotStorage _knotStorage;

    private RopeFactory _factory;

    public void InitializeFactory() => _factory = new RopeFactory(_config);

    public void Run()
    {

    }
}
