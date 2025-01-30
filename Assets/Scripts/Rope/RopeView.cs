using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class RopeView : MonoBehaviour
{
    private const int BegginingPositionIndex = 0;
    private const int EndginingPositionIndex = 1;

    [SerializeField] private Material _redMaterial;
    [SerializeField] private Material _greenMaterial;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLineBeggining(Vector2 position) => _lineRenderer.SetPosition(BegginingPositionIndex, position);
    public void SetLineEnding(Vector2 position) => _lineRenderer.SetPosition(EndginingPositionIndex, position);

    public void SetRed()
    {
        if (_lineRenderer.material != _redMaterial)
            _lineRenderer.material = _redMaterial;
    }

    public void SetGreen()
    {
        if (_lineRenderer.material != _greenMaterial)
            _lineRenderer.material = _greenMaterial;
    }
}
