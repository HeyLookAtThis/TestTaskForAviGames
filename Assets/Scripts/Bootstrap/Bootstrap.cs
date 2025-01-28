using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private KnotSpawner _spawner;

    private void Awake()
    {
        _spawner.InitializeFactory();
        _spawner.Run();
    }
}
