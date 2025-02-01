using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RopeStorage : MonoBehaviour
{
    private List<Rope> _ropes;
    private RopeCrossingChecker _checker;

    private UnityAction _ropesCameUndone;

    public event UnityAction RopesCameUndone
    {
        add => _ropesCameUndone += value;
        remove => _ropesCameUndone -= value;
    }

    private IReadOnlyList<Rope> Ropes => _ropes;

    private void Awake()
    {
        _ropes = new List<Rope>();
        _checker = new(Ropes);
    }

    private void Update()
    {
        _checker.Update();

        if (_checker.IsRopesFree)
            _ropesCameUndone?.Invoke();
    }

    public void Add(Rope rope) => _ropes.Add(rope);

    public void Hide()
    {
        foreach(var rope in _ropes)
            rope.Disable();
    }
}
