using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(/*typeof(RectTransform), */typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    private const int BegginingPositionIndex = 0;
    private const int EndginingPositionIndex = 1;

    [SerializeField] private RopeView _view;
    [SerializeField] private Transform _beginning;
    [SerializeField] private Transform _endning;

    //private RectTransform _rectTransform;
    private LineRenderer _lineRenderer;

    public LineRenderer LineRenderer => _lineRenderer;

    private void Awake()
    {
        //_rectTransform = GetComponent<RectTransform>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        SetBeginningPosition(_beginning.position);
        SetEndingPosition(_endning.position);
    }

    public void SetBeginningPosition(Vector3 position) => _lineRenderer.SetPosition(BegginingPositionIndex, position);
    public void SetEndingPosition(Vector3 position) => _lineRenderer.SetPosition(EndginingPositionIndex, position);

    private void SetLine()
    {
    }
}
