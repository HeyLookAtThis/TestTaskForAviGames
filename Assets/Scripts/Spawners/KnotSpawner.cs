using UnityEngine;

public class KnotSpawner : MonoBehaviour
{
    [SerializeField] private Knot _knootPrefab;
    [SerializeField] private KnotStorage _knotStorage;
    [SerializeField] private CursorPosition _cursor;

    [SerializeField, Range(3, 5)] private float _radius;

    [SerializeField] private Transform _rightCenterTransform;
    [SerializeField] private Transform _leftCenterTransform;

    private KnotFactory _factory;

    private int KnotCount => 14;
    private int SideCount => 2;
    private float AngleBetweenKnot => Mathf.PI / (KnotCount / SideCount + 1);

    private Vector2 RightCenter => _rightCenterTransform.position;
    private Vector2 LeftCenter => _leftCenterTransform.position;

    public void Initialize()
    {
        _knotStorage.Initialize();
        _factory = new KnotFactory(_knootPrefab, _knotStorage);
    }

    public void Run()
    {
        int leftSideMultiplier = 1;
        int rightSideMultiplier = -leftSideMultiplier;

        CreateKnotOnOneSide(LeftCenter, leftSideMultiplier);
        CreateKnotOnOneSide(RightCenter, rightSideMultiplier);
    }

    private void CreateKnotOnOneSide(Vector2 sideCenter, int angleMultiplier)
    {
        Vector2 position = new(sideCenter.x, sideCenter.y + _radius);

        for (int i = 0; i < KnotCount / SideCount; i++)
        {
            Knot knot = _factory.Get();
            knot.Initialize(_cursor);
            knot.SetPosition(position);
            _knotStorage.Add(knot);

            position = new(
                GetXAxisCoordinate(position, AngleBetweenKnot * angleMultiplier), 
                GetYAxisCoordinate(position, AngleBetweenKnot * angleMultiplier));
        }
    }

    private float GetXAxisCoordinate(Vector2 previous, float angle) => previous.x * Mathf.Cos(angle) - previous.y * Mathf.Sin(angle);
    private float GetYAxisCoordinate(Vector2 previous, float angle) => previous.x * Mathf.Sin(angle) + previous.y * Mathf.Cos(angle);
}
