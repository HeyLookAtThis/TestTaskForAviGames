using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnotSpawner : MonoBehaviour
{
    [SerializeField] private Knot _knootPrefab;
    [SerializeField] private KnotStorage _knotStorage;
    [SerializeField] private CursorPosition _cursor;

    [SerializeField, Range(3, 5)] private float _radius;

    [SerializeField] private Transform _rightCenterTransform;
    [SerializeField] private Transform _leftCenterTransform;

    private KnotFactory _factory;
    private List<Knot> _notSpawnedKnots;

    private int KnotCount => 14;
    private int SideCount => 2;
    private float AngleBetweenKnot => Mathf.PI / (KnotCount / SideCount + 1);

    private Vector2 RightCenter => _rightCenterTransform.position;
    private Vector2 LeftCenter => _leftCenterTransform.position;

    public void Initialize()
    {
        _knotStorage.Initialize();
        _factory = new KnotFactory(_knootPrefab, _knotStorage);
        InitializeKnots();
    }

    public void Run()
    {
        Spawn();
    }

    public void Respawn()
    {
        ResetNotSpawnedKnots();

        for (int i = 0; i < KnotCount; i++)
            _knotStorage.Get(i).View.DoFade();

        Spawn();
    }

    private void Spawn()
    {
        int leftSideMultiplier = 1;
        int rightSideMultiplier = -leftSideMultiplier;

        SetPositionOnOneSide(LeftCenter, leftSideMultiplier);
        SetPositionOnOneSide(RightCenter, rightSideMultiplier);
    }

    private void SetPositionOnOneSide(Vector2 sideCenter, int angleMultiplier)
    {
        Vector2 position = new(sideCenter.x, sideCenter.y + _radius);
        int notSpawnedKnotIndex = 0;

        for (int i = 0; i < KnotCount / SideCount; i++)
        {
            _notSpawnedKnots[notSpawnedKnotIndex].SetPosition(position);
            _notSpawnedKnots.RemoveAt(notSpawnedKnotIndex);

            position = new(
                GetXAxisCoordinate(position, AngleBetweenKnot * angleMultiplier), 
                GetYAxisCoordinate(position, AngleBetweenKnot * angleMultiplier));
        }
    }

    private void InitializeKnots()
    {
        _notSpawnedKnots = new List<Knot>();

        for (int i = 0; i < KnotCount; i++)
        {
            Knot knot = _factory.Get();
            knot.Initialize(_cursor);
            _knotStorage.Add(knot);
            _notSpawnedKnots.Add(knot);
        }
    }

    private void ResetNotSpawnedKnots()
    {
        _notSpawnedKnots.Clear();

        for (int i = 0; i < _knotStorage.Count; i++)
            _notSpawnedKnots.Add(_knotStorage.Get(i));
    }

    private float GetXAxisCoordinate(Vector2 previous, float angle) => previous.x * Mathf.Cos(angle) - previous.y * Mathf.Sin(angle);
    private float GetYAxisCoordinate(Vector2 previous, float angle) => previous.x * Mathf.Sin(angle) + previous.y * Mathf.Cos(angle);
}
