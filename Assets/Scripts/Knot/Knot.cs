using System.Collections.Generic;
using UnityEngine;

public class Knot : MonoBehaviour
{
    private List<Knot> _connectedKnots;

    public Vector2 Position => transform.position;

    private void Awake() => _connectedKnots = new List<Knot>();

    public void SetPosition(Vector3 position) => transform.position = position;
    public void AddConnect(Knot knot) => _connectedKnots.Add(knot);
    public bool HaveConnect(Knot knot) => _connectedKnots.Contains(knot);
}
