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

    public void Create(Vector2 beggining, Vector2 ending)
    {
        Rope rope = Object.Instantiate(_config.Prefab, _storage.transform);
        rope.SetBeginningPosition(beggining);
        rope.SetEndingPosition(ending);
    }
}
