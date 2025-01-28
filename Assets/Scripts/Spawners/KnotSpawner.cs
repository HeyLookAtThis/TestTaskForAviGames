using UnityEngine;

public class KnotSpawner : MonoBehaviour
{
    [SerializeField] private Knot _knootPrefab;
    [SerializeField] private KnotStorage _knotStorage;

    [SerializeField, Range(3, 5)] private float _radius;

    [SerializeField] private Transform _rightCenterTransform;
    [SerializeField] private Transform _leftCenterTransform;

    private KnotFactory _factory;

    private int KnotCount => 14; 
    private Vector2 RightCenter => _rightCenterTransform.position;
    private Vector2 LeftCenter => _leftCenterTransform.position;

    public void InitializeFactory() => _factory = new KnotFactory(_knootPrefab, _knotStorage);

    public void Run()
    {
        int sideCount = 2;
        int countInOneSide = KnotCount / sideCount;
        float oneSideAngle = 180;
        float angleBetweenKnot = oneSideAngle / KnotCount * sideCount;

        float defaultLeftAngle = _leftCenterTransform.rotation.eulerAngles.y;
        float defaultRightAngle = _rightCenterTransform.rotation.eulerAngles.y;

        float currentAngle = angleBetweenKnot;

        for (int i = 0; i < KnotCount; i++)
        {
            SpawnKnot(LeftCenter, defaultLeftAngle, ref i);
            SpawnKnot(RightCenter, defaultRightAngle, ref i);

            for (int j = 1; j < countInOneSide; j++)
            {
                CreateSymmetricalTopAndBottomPair(LeftCenter, defaultLeftAngle, currentAngle, ref i);
                CreateSymmetricalTopAndBottomPair(RightCenter, defaultRightAngle, currentAngle, ref i);

                currentAngle += angleBetweenKnot;

                j++;
            }
        }
    }

    private void CreateSymmetricalTopAndBottomPair(Vector2 center,float defaultAngle, float currentAngle, ref int i)
    {
        float positiveAngle = defaultAngle + currentAngle;
        float negativeAngle = defaultAngle - currentAngle;

        SpawnKnot(center, positiveAngle, ref i);
        SpawnKnot(center, negativeAngle, ref i);
    }

    private void SpawnKnot(Vector2 center, float angle, ref int i)
    {
        Vector2 position = GetPosition(center, angle);
        _factory.Get().SetPosition(position);
        i++;
    }

    private Vector2 GetPosition(Vector2 center, float angle) => new Vector2(GetXCoordinate(center.x, angle), GetYCoordinate(center.y, angle));
    private float GetXCoordinate(float xPosition,float angle) => xPosition + _radius * Mathf.Cos(angle);
    private float GetYCoordinate(float yPosition,float angle) => yPosition + _radius * Mathf.Sin(angle);
}
