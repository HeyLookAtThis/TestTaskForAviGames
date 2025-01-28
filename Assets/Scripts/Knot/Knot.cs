using System.Collections.Generic;
using UnityEngine;

public class Knot : MonoBehaviour
{
    private List<Knot> _connectedKnots;
    private void Awake() => _connectedKnots = new List<Knot>();
    public void SetPosition(Vector3 position) => transform.position = position;
    public void AddRelatedKnots(Knot knot) => _connectedKnots.Add(knot);
    public bool HaveConnected(Knot knot) => _connectedKnots.Contains(knot);
}
