using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private KnotSpawner _knotSpawner;
    [SerializeField] private RopeSpawner _ropeSpawner;

    private void Awake()
    {
        _knotSpawner.Initialize();
        _ropeSpawner.Initialize();

        _knotSpawner.Run();
        _ropeSpawner.Run();
    }
}
