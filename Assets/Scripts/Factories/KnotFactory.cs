using UnityEngine;

public class KnotFactory
{
    private Knot _prefab;
    private KnotStorage _storage;

    public KnotFactory(Knot prefab, KnotStorage storage)
    {
        _prefab = prefab;
        _storage = storage;
    }

    public Knot Get()
    {
        Knot knot = Object.Instantiate(_prefab, _storage.transform);
        return knot;
    }
}
