using System.Collections.Generic;
using UnityEngine;

public class KnotStorage : MonoBehaviour
{
    private List<Knot> _knots;
    private KnotPointerPressChecker _checker;

    public int Count => _knots.Count;
    public KnotPointerPressChecker Checker => _checker;
    private IReadOnlyList<Knot> Knots => _knots;

    private void Update() => _checker.Update();

    public void Initialize()
    {
        _knots = new List<Knot>();
        _checker = new(Knots);
    }

    public void Add(Knot knot) => _knots.Add(knot);
    public Knot Get(int index) => _knots[index];
    public void Dasable() => gameObject.SetActive(false);
}
