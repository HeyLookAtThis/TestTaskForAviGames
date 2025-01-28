using UnityEngine;

public class KnotFactory
{
    private Knot _prefab;

    private GameObject _storage;

    public KnotFactory(Knot prefab)
    {
        _prefab = prefab;
    }

    public Knot Get()
    {
        if (_storage == null)
            _storage = new("Knoots");

        Knot knot = Object.Instantiate(_prefab, _storage.transform);
        return knot;
    }
}
