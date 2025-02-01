using UnityEngine;

public class RopeFactory
{
    private RopesConfig _config;
    private GameObject _storage;

    public RopeFactory(RopesConfig config, GameObject storage)
    {
        _config = config;
        _storage = storage;
    }

    public Rope Create(Knot beggining, Knot ending)
    {
        Rope rope = Object.Instantiate(_config.Prefab, _storage.transform);
        rope.Initialize(beggining, ending);
        return rope;
    }
}
