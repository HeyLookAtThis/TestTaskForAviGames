using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    private const int BegginingPositionIndex = 0;
    private const int EndginingPositionIndex = 1;

    [SerializeField] private RopeView _view;

    private LineRenderer _lineRenderer;

    public LineRenderer LineRenderer => _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetBeginningPosition(Vector3 position) => _lineRenderer.SetPosition(BegginingPositionIndex, position);
    public void SetEndingPosition(Vector3 position) => _lineRenderer.SetPosition(EndginingPositionIndex, position);
}
