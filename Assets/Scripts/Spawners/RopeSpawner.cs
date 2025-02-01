using UnityEngine;

public class RopeSpawner : MonoBehaviour
{
    [SerializeField] private RopesConfig _config;
    [SerializeField] private KnotStorage _knotStorage;
    [SerializeField] private RopeStorage _ropeStorage;

    private KnotConnectionsData _connections;
    private RopeFactory _factory;

    public void Initialize()
    {
        _connections = new KnotConnectionsData();
        _factory = new RopeFactory(_config, _ropeStorage.gameObject);
    }

    public void Run()
    {
        for (int i = 0; i < _knotStorage.Count; i++)
        {
            for (int j = 0; j < _connections.GetConnectionCount(i); j++)
            {
                int knotIndex = _connections.GetConnection(i, j);

                Knot begginer = _knotStorage.Get(i);
                Knot ender = _knotStorage.Get(knotIndex);

                Rope rope = _factory.Create(begginer, ender);
                _ropeStorage.Add(rope);
            }
        }
    }

    public void Clear()
    {
        _ropeStorage.Hide();
    }
}
