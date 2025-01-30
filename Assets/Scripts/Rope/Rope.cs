using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Rope : MonoBehaviour
{
    [SerializeField] private RopeView _view;

    private EdgeCollider2D _edgeCollider;

    private Knot _beginningKnot;
    private Knot _endningKnot;

    public bool IsCrossing { get; private set; }

    private Vector2 Start => _beginningKnot.Position;
    private Vector2 End => _endningKnot.Position;

    private void Awake() => _edgeCollider = GetComponent<EdgeCollider2D>();

    private void OnDisable()
    {
        _beginningKnot.PositionChanged -= OnSetBeginningPosition;
        _endningKnot.PositionChanged -= OnSetEndingPosition;
    }

    private void Update() => SetCrossing();

    public void Initialize(Knot begginingKnot, Knot endingKnot)
    {
        _beginningKnot = begginingKnot;
        _endningKnot = endingKnot;

        OnSetBeginningPosition(Start);
        OnSetEndingPosition(End);
        SetCrossing();

        _beginningKnot.PositionChanged += OnSetBeginningPosition;
        _endningKnot.PositionChanged += OnSetEndingPosition;
    }

    private void SetColliderPoints()
    {
        float indent = 0.75f;

        Vector2 starting = (End - Start).normalized * indent;
        Vector2 ending = (Start - End).normalized * indent;

        List<Vector2> points = new() {Start + starting, End + ending };
        _edgeCollider.SetPoints(points);
    }

    private void OnSetBeginningPosition(Vector2 position)
    {
        _view.SetLineBeggining(position);
        SetColliderPoints();
    }

    private void OnSetEndingPosition(Vector2 position)
    {
        _view.SetLineEnding(position);
        SetColliderPoints();
    }

    private void SetCrossing()
    {
        List<Collider2D> result = new();

        _edgeCollider.OverlapCollider(new(), result);

        var collider = result.FirstOrDefault(collider => collider is EdgeCollider2D || collider is CircleCollider2D);

        if (collider != null)
        {
            IsCrossing = true;
            _view.SetRed();
        }
        else
        {
            IsCrossing = false;
            _view.SetGreen();
        }
    }
}
