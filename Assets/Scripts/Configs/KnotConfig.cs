using UnityEngine;

[CreateAssetMenu(fileName = "KnotKonfig", menuName = "Configs/KnotConfig")]
public class KnotConfig : ScriptableObject
{
    [SerializeField] private Knot _prefab;
    [SerializeField] private int _ropeCount;

    public Knot Prefab => _prefab;
    public int RopeCount => _ropeCount;
}
