using System.Collections.Generic;
using UnityEngine;

public class KnotStorage : MonoBehaviour
{
    private List<Knot> _knots;

    public int Count => _knots.Count;

    public void Initialize() => _knots = new List<Knot>();

    public void Add(Knot knot) => _knots.Add(knot);
    public Knot Get(int index) => _knots[index];
}
