using UnityEngine;

public class RopeFactory
{
    private RopesConfig _config;
    private GameObject _storage;

    public RopeFactory(RopesConfig config)
    {
        _config = config;
        _storage = new GameObject("Ropes");
    }

    public void Create(Knot beggining, Knot ending)
    {
        Rope rope = Object.Instantiate(_config.Prefab, _storage.transform);
        rope.Initialize(beggining, ending, _config.LayerMask);
    }
}
