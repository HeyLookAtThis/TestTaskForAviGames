using System.Collections.Generic;
using UnityEngine;

public class RopeStorage : MonoBehaviour
{
    private List<Rope> _ropes;
    private RopeCrossingChecker _checker;

    public RopeCrossingChecker Checker => _checker;
    private IReadOnlyList<Rope> Ropes => _ropes;

    private void Update() => _checker.Update();

    public void Initialize()
    {
        _ropes = new List<Rope>();
        _checker = new(Ropes);
    }

    public void Add(Rope rope) => _ropes.Add(rope);

    public void Hide()
    {
        foreach(var rope in _ropes)
            rope.Disable();
    }
}
