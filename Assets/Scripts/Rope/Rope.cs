using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
public class Rope : MonoBehaviour
{
    private const int BegginingPositionIndex = 0;
    private const int EndginingPositionIndex = 1;

    [SerializeField] private RopeView _view;

    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeCollider;

    private LayerMask _layerMask;
    private Knot _beginningKnot;
    private Knot _endningKnot;

    public LineRenderer LineRenderer => _lineRenderer;
    public bool IsCrossing { get; private set; }

    private Vector2 Start => _beginningKnot.Position;
    private Vector2 End => _endningKnot.Position;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void OnDisable()
    {
        _beginningKnot.PositionChanged -= OnSetBeginningPosition;
        _endningKnot.PositionChanged -= OnSetEndingPosition;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(Start, End, _layerMask);

        if (hit.collider.TryGetComponent<Rope>(out Rope rope))
        {
            IsCrossing = true;
            _view.SetRed();
        }

        if(hit == false)
        {
            IsCrossing = false;
            _view.SetGreen();
        }
    }

    public void Initialize(Knot begginingKnot, Knot endingKnot, LayerMask layerMask)
    {
        _beginningKnot = begginingKnot;
        _endningKnot = endingKnot;

        _layerMask = layerMask;

        OnSetBeginningPosition(Start);
        OnSetEndingPosition(End);

        _beginningKnot.PositionChanged += OnSetBeginningPosition;
        _endningKnot.PositionChanged += OnSetEndingPosition;
    }

    private void SetColliderPoints()
    {
        List<Vector2> points = new() { Start, End };
        _edgeCollider.SetPoints(points);
    }

    private void OnSetBeginningPosition(Vector2 position)
    {
        _lineRenderer.SetPosition(BegginingPositionIndex, position);
        SetColliderPoints();
    }

    private void OnSetEndingPosition(Vector2 position)
    {
        _lineRenderer.SetPosition(EndginingPositionIndex, position);
        SetColliderPoints();
    }
}
